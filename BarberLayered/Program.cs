using Microsoft.AspNetCore.Identity.UI.Services;
using BarberLayered.Filters;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Identity;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Log.Information("Server started, logger is working");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Log Filter
builder.Services.AddControllers(config => config.Filters.Add<LogActionFilter>());
builder.Services.AddScoped<LogActionFilter>();

// Repositories
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IApplicationUsersHelper, ApplicationUsersHelper>();
builder.Services.AddScoped<IBarberRepository, BarberRepository>();
builder.Services.AddScoped<IBarberShopRepository, BarberShopRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IRegistrationKeyRepository, RegistrationKeyRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();


// Services
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IBarberHomeService, BarberHomeService>();
builder.Services.AddScoped<IBarberService, BarberService>();
builder.Services.AddScoped<IBarberShopService, BarberShopService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
//builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IRegistrationKeyService, RegistrationKeyService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IVisitService, VisitService>();
//builder.Services.AddScoped<IChangePasswordService, ChangePasswordService>();


SecretClientOptions options = new SecretClientOptions()
{
    Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
};
var client = new SecretClient(new Uri("https://barberbookvault.vault.azure.net/"), new DefaultAzureCredential(), options);

KeyVaultSecret secret = client.GetSecret("barberbook-db-azure");

string azureDbConnectionString = secret.Value;

// DbContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(azureDbConnectionString, x => x.MigrationsAssembly("DataAccessLayer"));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("BarberBook_Connection"), x => x.MigrationsAssembly("DataAccessLayer"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<DataContext>();

builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//}).AddCookie(options =>
//{
//    options.LoginPath = "/Areas/Identity/Pages/Account/Login";
//});

var app = builder.Build();
Log.Information("Application built, service started");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BarberShop}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Barber", "Client" };

    foreach(var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.Run();

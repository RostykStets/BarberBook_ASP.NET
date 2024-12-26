namespace DataAccessLayer.Entities
{
    public class Barber
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? PhotoUri { get; set; }
        public string? Description { get; set; }
        public string? PortfolioUri { get; set; }

        public Barber() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PasswordHash = "";
            PhotoUri = "";
            Description = "";
            PortfolioUri = "";
        }

        public Barber(ApplicationUser? applicationUser)
        {
            Id = applicationUser.Id ?? "";
            Name = applicationUser.UserName ?? "";
            Surname = "";
            Phone = applicationUser.PhoneNumber ?? "";
            Email = applicationUser.Email ?? "";
            PasswordHash = applicationUser.PasswordHash ?? "";
            PhotoUri = applicationUser.PhotoUri;
            Description = applicationUser.Description;
            PortfolioUri = applicationUser.PortfolioUri;
        }
    }
}

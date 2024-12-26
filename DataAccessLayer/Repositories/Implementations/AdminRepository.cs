using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;
        private readonly IApplicationUsersHelper _applicationUsersHelper;

        public AdminRepository(DataContext context, IApplicationUsersHelper applicationUsersHelper)
        {
            _context = context;
            _applicationUsersHelper = applicationUsersHelper;
        }

        public async Task<IEnumerable<Admin>> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();

            var adminRoles = await _applicationUsersHelper.GetRolesToUsers("Admin");
            foreach (var adminRole in adminRoles)
            {
                admins.Add(new Admin(adminRole));
            }

            return admins.ToList();
        }

        public async Task<Admin?> GetAdminByID(string adminId)
        {
            var appUser = await _context.ApplicationUsers.FindAsync(adminId);
            if (appUser == null)
            {
                return null;
            }
            return new Admin(appUser);
        }

        public async Task<Admin?> GetAdminByEmail(string email)
        {
            var appUsers = await _applicationUsersHelper.GetRolesToUsers("Admin");
            ApplicationUser? appUser = appUsers.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (appUser == null)
            {
                return null;
            }

            return new Admin(appUser);
        }
    }
}

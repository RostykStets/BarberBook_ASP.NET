using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class ApplicationUsersHelper : IApplicationUsersHelper
    {
        private readonly DataContext _context;

        public ApplicationUsersHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetRolesToUsers(string roleName)
        {
            var usersInRole = new List<ApplicationUser>();

            var roleToFind = await _context.Roles.Where(x => x.Name == roleName).ToListAsync();
            // Id of the selected role
            string roleId = roleToFind.FirstOrDefault().Id;
            // UserRoles rows with selected role
            var usersRole = await _context.UserRoles.Where(role => role.RoleId == roleId).ToListAsync(); 

            foreach (var user in usersRole)
            {
                var userInRole = await _context.ApplicationUsers.Where(x => x.Id == user.UserId).FirstAsync();
                usersInRole.Add(userInRole);
            }

            return usersInRole;
        }
    }
}

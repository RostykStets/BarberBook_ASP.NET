using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IApplicationUsersHelper
    {
        public Task<List<ApplicationUser>> GetRolesToUsers(string roleName);
    }
}

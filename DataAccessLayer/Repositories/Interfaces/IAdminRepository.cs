using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAdmins();
        Task<Admin?> GetAdminByID(string adminId);
        Task<Admin?> GetAdminByEmail(string email);
    }
}

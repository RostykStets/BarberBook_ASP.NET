using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<AdminDto>> GetAdmins();
        Task<AdminDto?> GetAdminById(string adminId);
        Task<AdminDto?> GetAdminByEmail(string email);
    }
}

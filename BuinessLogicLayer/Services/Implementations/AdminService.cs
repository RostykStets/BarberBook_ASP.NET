using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<List<AdminDto>> GetAdmins()
        {
            var admins = await _adminRepository.GetAdmins();
            var adminsDtos = from admin in admins
                             select new AdminDto(admin);
            return adminsDtos.ToList();
        }

        public async Task<AdminDto?> GetAdminById(string adminId)
        {
            var admin = await _adminRepository.GetAdminByID(adminId);

            AdminDto? adminDto = null;
            if (null != admin)
            {
                adminDto = new AdminDto(admin);
            }
            return adminDto;
        }

        public async Task<AdminDto?> GetAdminByEmail(string email)
        {
            Admin? admin = await _adminRepository.GetAdminByEmail(email);
            AdminDto? adminDto = null;
            if (admin != null)
            {
                adminDto = new AdminDto(admin);
            }
            return adminDto;
        }
    }
}

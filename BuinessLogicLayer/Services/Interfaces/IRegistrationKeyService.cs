using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRegistrationKeyService
    {
        Task<List<RegistrationKeyDto>> GetRegistrationKeys();
        Task<RegistrationKeyDto?> GetRegistrationKeyById(int registrationKeyId);
        Task<RegistrationKeyDto?> GetRegistrationKeyFirst();
        Task InsertRegistrationKey(RegistrationKeyDto registrationKeyDto);
        Task DeleteRegistrationKey(int registrationKeyId);
        Task UpdateRegistrationKey(RegistrationKeyDto registrationKeyDto);
    }
}

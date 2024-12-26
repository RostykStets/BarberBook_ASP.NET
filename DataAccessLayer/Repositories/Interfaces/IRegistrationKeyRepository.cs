using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRegistrationKeyRepository
    {
        Task<IEnumerable<RegistrationKey>> GetRegistrationKeys();
        Task<RegistrationKey?> GetRegistrationKeyByID(int registrationKeyId);
        Task<RegistrationKey?> GetRegistrationKeyFirst();
        Task InsertRegistrationKey(RegistrationKey registrationKey);
        Task DeleteRegistrationKey(int registrationKeyId);
        Task UpdateRegistrationKey(RegistrationKey registrationKey);
        Task Save();
    }
}

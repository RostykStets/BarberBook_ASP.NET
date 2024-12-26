using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class RegistrationKeyService : IRegistrationKeyService
    {
        private readonly IRegistrationKeyRepository _registrationKeyRepository;

        public RegistrationKeyService(IRegistrationKeyRepository registrationKeyRepository)
        {
            _registrationKeyRepository = registrationKeyRepository;
        }
        public async Task DeleteRegistrationKey(int registrationKeyId)
        {
            await _registrationKeyRepository.DeleteRegistrationKey(registrationKeyId);
        }

        public async Task<RegistrationKeyDto?> GetRegistrationKeyFirst()
        {
            var registrationKey = await _registrationKeyRepository.GetRegistrationKeyFirst();

            RegistrationKeyDto? registrationKeyDto = null;
            if (null != registrationKey)
            {
                registrationKeyDto = new RegistrationKeyDto(registrationKey);
            }
            return registrationKeyDto;
        }

        public async Task<RegistrationKeyDto?> GetRegistrationKeyById(int registrationKeyId)
        {
            var registrationKey = await _registrationKeyRepository.GetRegistrationKeyByID(registrationKeyId);

            RegistrationKeyDto? registrationKeyDto = null;
            if (null != registrationKey)
            {
                registrationKeyDto = new RegistrationKeyDto(registrationKey);
            }
            return registrationKeyDto;
        }

        public async Task<List<RegistrationKeyDto>> GetRegistrationKeys()
        {
            var registrationKeys = await _registrationKeyRepository.GetRegistrationKeys();
            var registrationKeyDtos = from registrationKey in registrationKeys
                                      select new RegistrationKeyDto(registrationKey);
            return registrationKeyDtos.ToList();
        }

        public async Task InsertRegistrationKey(RegistrationKeyDto registrationKeyDto)
        {
            RegistrationKey registrationKey = registrationKeyDto.ToEntity();
            await _registrationKeyRepository.InsertRegistrationKey(registrationKey);
        }

        public async Task UpdateRegistrationKey(RegistrationKeyDto registrationKeyDto)
        {
            RegistrationKey registrationKey = registrationKeyDto.ToEntity();
            await _registrationKeyRepository.UpdateRegistrationKey(registrationKey);
        }
    }
}

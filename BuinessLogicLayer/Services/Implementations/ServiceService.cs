using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceDto>> GetServices()
        {
            var services = await _serviceRepository.GetServices();
            var servicesDtos = from service in services
                               select new ServiceDto(service);
            return servicesDtos.ToList();
        }

        public async Task<ServiceDto?> GetServiceByID(int serviceId)
        {
            Service? service = await _serviceRepository.GetServiceByID(serviceId);
            ServiceDto? serviceDto = null;
            if (service != null)
            {
                serviceDto = new ServiceDto(service);
            }
            return serviceDto;
        }

        public async Task<List<ServiceDto>> GetServicesByBarberId(string fkBarberId)
        {
            var services = await _serviceRepository.GetServicesByBarberId(fkBarberId);

            var servicesDtos = from service in services
                               select new ServiceDto(service);
            return servicesDtos.ToList();
        }

        public async Task InsertService(ServiceDto serviceDto)
        {
            Service service = serviceDto.ToEntity();
            await _serviceRepository.InsertService(service);
        }

        public async Task DeleteService(int serviceId)
        {
            await _serviceRepository.DeleteService(serviceId);
        }

        public async Task UpdateService(ServiceDto serviceDto)
        {
            Service service = serviceDto.ToEntity();
            await _serviceRepository.UpdateService(service);
        }
    }
}

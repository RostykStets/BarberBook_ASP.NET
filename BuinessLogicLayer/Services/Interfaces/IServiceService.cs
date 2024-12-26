using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceDto>> GetServices();
        Task<ServiceDto?> GetServiceByID(int serviceId);
        Task<List<ServiceDto>> GetServicesByBarberId(string fkBarberId);
        Task InsertService(ServiceDto serviceDto);
        Task DeleteService(int serviceId);
        Task UpdateService(ServiceDto serviceDto);
    }
}

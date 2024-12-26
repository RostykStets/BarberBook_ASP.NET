using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetServices();
        Task<Service?> GetServiceByID(int serviceId);
        Task<IEnumerable<Service>> GetServicesByBarberId(string fkBarberId);
        Task InsertService(Service service);
        Task DeleteService(int serviceId);
        Task UpdateService(Service service);
        Task Save();
    }
}

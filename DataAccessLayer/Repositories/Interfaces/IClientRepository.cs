using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client?> GetClientByID(string clientId);
        Task<Client?> GetClientByEmail(string email);
    }
}

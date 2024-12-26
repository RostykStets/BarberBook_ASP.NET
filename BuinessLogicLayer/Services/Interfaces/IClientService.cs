using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetClients();
        Task<ClientDto?> GetClientById(string clientId);
        Task<ClientDto?> GetClientByEmail(string email);
    }
}

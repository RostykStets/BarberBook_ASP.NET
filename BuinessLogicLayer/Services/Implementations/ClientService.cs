using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> GetClients()
        {
            var clients = await _clientRepository.GetClients();
            var clientsDtos = from client in clients
                              select new ClientDto(client);
            return clientsDtos.ToList();
        }

        public async Task<ClientDto?> GetClientById(string clientId)
        {
            var client = await _clientRepository.GetClientByID(clientId);

            ClientDto? clientDto = null;
            if (null != client)
            {
                clientDto = new ClientDto(client);
            }
            return clientDto;
        }

        public async Task<ClientDto?> GetClientByEmail(string email)
        {
            Client? client = await _clientRepository.GetClientByEmail(email);
            ClientDto? clientDto = null;
            if (client != null)
            {
                clientDto = new ClientDto(client);
            }
            return clientDto;
        }
    }
}

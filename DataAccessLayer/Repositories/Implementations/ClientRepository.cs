using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IApplicationUsersHelper _applicationUsersHelper;

        public ClientRepository(DataContext context, IApplicationUsersHelper applicationUsersHelper)
        {
            _context = context;
            _applicationUsersHelper = applicationUsersHelper;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            List<Client> clients = new List<Client>();

            var clientRoles = await _applicationUsersHelper.GetRolesToUsers("Client");
            foreach (var clientRole in clientRoles)
            {
                clients.Add(new Client(clientRole));
            }

            return clients.ToList();
        }

        public async Task<Client?> GetClientByID(string clientId)
        {
            var appUser = await _context.ApplicationUsers.FindAsync(clientId);
            if (appUser == null)
            {
                return null;
            }
            return new Client(appUser);
        }

        public async Task<Client?> GetClientByEmail(string email)
        {
            var appUsers = await _applicationUsersHelper.GetRolesToUsers("Client");
            var appUser = appUsers.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (appUser == null)
            {
                return null;
            }

            return new Client(appUser);
        }
    }
}

using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DataContext _context;
        private readonly IApplicationUsersHelper _applicationUsersHelper;

        public BarberRepository(DataContext context, IApplicationUsersHelper applicationUsersHelper)
        {
            _context = context;
            _applicationUsersHelper = applicationUsersHelper;
        }

        public async Task<IEnumerable<Barber>> GetBarbers()
        {
            List<Barber> barbers = new List<Barber>();

            var barberRoles = await _applicationUsersHelper.GetRolesToUsers("Barber");
            foreach (var barberRole in barberRoles)
            {
                barbers.Add(new Barber(barberRole));
            }

            return barbers.ToList();


        }

        public async Task<Barber?> GetBarberByID(string barberId)
        {
            var appUser = await _context.ApplicationUsers.FindAsync(barberId);
            if (appUser == null)
            {
                return null;
            }
            return new Barber(appUser);
        }

        public async Task<Barber?> GetBarberByEmail(string email)
        {
            var appUsers = await _applicationUsersHelper.GetRolesToUsers("Barber");
            ApplicationUser? appUser = appUsers.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (appUser == null)
            {
                return null;
            }

            return new Barber(appUser);
        }
    }
}

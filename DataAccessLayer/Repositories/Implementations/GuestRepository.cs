using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DataContext _context;

        public GuestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guest>> GetGuests()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetGuestByID(int guestId)
        {
            return await _context.Guests.FindAsync(guestId);
        }

        public async Task InsertGuest(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            await Save();
        }

        public async Task DeleteGuest(int guestId)
        {
            Guest? guest = await _context.Guests.FindAsync(guestId);
            if (null != guest) _context.Guests.Remove(guest);
            await Save();
        }

        public async Task UpdateGuest(Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

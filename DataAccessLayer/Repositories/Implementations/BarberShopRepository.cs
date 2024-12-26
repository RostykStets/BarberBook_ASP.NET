using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class BarberShopRepository : IBarberShopRepository
    {
        private readonly DataContext _context;

        public BarberShopRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BarberShop>> GetBarberShops()
        {
            return await _context.BarberShops.ToListAsync();
        }

        public async Task<BarberShop?> GetBarberShopByID(int barbershopId)
        {
            return await _context.BarberShops.FindAsync(barbershopId);
        }

        public async Task<BarberShop?> GetBarberShopFirst()
        {
            return await _context.BarberShops.FirstOrDefaultAsync();
        }

        public async Task InsertBarberShop(BarberShop barbershop)
        {
            await _context.BarberShops.AddAsync(barbershop);
            await Save();
        }

        public async Task DeleteBarberShop(int barbershopId)
        {
            BarberShop? barbershop = await _context.BarberShops.FindAsync(barbershopId);
            if (null != barbershop) _context.BarberShops.Remove(barbershop);
            await Save();
        }

        public async Task UpdateBarberShop(BarberShop barbershop)
        {
            _context.Entry(barbershop).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

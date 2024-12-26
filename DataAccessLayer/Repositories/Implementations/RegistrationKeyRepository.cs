using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class RegistrationKeyRepository : IRegistrationKeyRepository
    {
        private readonly DataContext _context;

        public RegistrationKeyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistrationKey>> GetRegistrationKeys()
        {
            return await _context.RegistrationKeys.ToListAsync();
        }

        public async Task<RegistrationKey?> GetRegistrationKeyByID(int registrationKeyId)
        {
            return await _context.RegistrationKeys.FindAsync(registrationKeyId);
        }

        public async Task<RegistrationKey?> GetRegistrationKeyFirst()
        {
            return await _context.RegistrationKeys.FirstAsync();
        }

        public async Task InsertRegistrationKey(RegistrationKey registrationKey)
        {
            await _context.RegistrationKeys.AddAsync(registrationKey);
            await Save();
        }

        public async Task DeleteRegistrationKey(int registrationKeyId)
        {
            RegistrationKey? registrationKey = await _context.RegistrationKeys.FindAsync(registrationKeyId);
            if (null != registrationKey) _context.RegistrationKeys.Remove(registrationKey);
            await Save();
        }

        public async Task UpdateRegistrationKey(RegistrationKey registrationKey)
        {
            _context.Entry(registrationKey).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

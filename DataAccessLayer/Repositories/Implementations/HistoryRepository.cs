using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DataContext _context;

        public HistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<History>> GetHistorys()
        {
            return await _context.History.ToListAsync();
        }

        public async Task<History?> GetHistoryByID(int historyId)
        {
            return await _context.History.FindAsync(historyId);
        }

        public async Task InsertHistory(History history)
        {
            await _context.History.AddAsync(history);
            await Save();
        }

        public async Task DeleteHistory(int historyId)
        {
            History? history = await _context.History.FindAsync(historyId);
            if (null != history) _context.History.Remove(history);
            await Save();
        }

        public async Task UpdateHistory(History history)
        {
            _context.Entry(history).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

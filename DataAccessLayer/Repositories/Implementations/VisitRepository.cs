using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class VisitRepository : IVisitRepository
    {
        private readonly DataContext _context;

        public VisitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visit>> GetVisits()
        {
            return await _context.Visits.ToListAsync();
        }

        public async Task<IEnumerable<Visit>> GetVisitsByBarberId(string fk_BarberId)
        {
            return await _context.Visits.Where(x => x.fk_BarberId == fk_BarberId).ToListAsync();
        }

        public async Task<Visit?> GetVisitByID(int visitId)
        {
            return await _context.Visits.FindAsync(visitId);
        }

        public async Task InsertVisit(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
            await Save();
        }

        public async Task DeleteVisit(int visitId)
        {
            Visit? visit = await _context.Visits.FindAsync(visitId);
            if (null != visit) _context.Visits.Remove(visit);
            await Save();
        }

        public async Task UpdateVisit(Visit visit)
        {
            _context.Entry(visit).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _context;

        public ScheduleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedule>> GetSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule?> GetScheduleByID(int scheduleId)
        {
            return await _context.Schedules.FindAsync(scheduleId);
        }

        public async Task<IEnumerable<Schedule>> GetScheduleByBarberID(string fkBarberId)
        {
            return await _context.Schedules.Where(x => x.fk_BarberId == fkBarberId).ToListAsync();
        }

        public async Task InsertSchedule(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await Save();
        }

        public async Task DeleteSchedule(int scheduleId)
        {
            Schedule? schedule = await _context.Schedules.FindAsync(scheduleId);
            if (null != schedule) _context.Schedules.Remove(schedule);
            await Save();
        }

        public async Task UpdateSchedule(Schedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

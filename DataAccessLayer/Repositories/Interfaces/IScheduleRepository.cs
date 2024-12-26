using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetSchedules();
        Task<Schedule?> GetScheduleByID(int scheduleId);
        Task<IEnumerable<Schedule>> GetScheduleByBarberID(string fkBarberId);
        Task InsertSchedule(Schedule schedule);
        Task DeleteSchedule(int scheduleId);
        Task UpdateSchedule(Schedule schedule);
        Task Save();
    }
}

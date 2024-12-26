using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetSchedules();
        Task<ScheduleDto?> GetScheduleByID(int scheduleId);
        Task<List<ScheduleDto>> GetScheduleByBarberID(string barberId);
        Task InsertSchedule(ScheduleDto scheduleDto);
        Task DeleteSchedule(int scheduleId);
        Task UpdateSchedule(ScheduleDto scheduleDto);
    }
}

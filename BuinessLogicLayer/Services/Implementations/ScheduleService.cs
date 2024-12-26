using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task DeleteSchedule(int scheduleId)
        {
            await _scheduleRepository.DeleteSchedule(scheduleId);
        }
        public async Task<List<ScheduleDto>> GetSchedules()
        {
            var schedules = await _scheduleRepository.GetSchedules();
            var schedulesDtos = from schedule in schedules
                                select new ScheduleDto(schedule);
            return schedulesDtos.ToList();
        }

        public async Task<ScheduleDto?> GetScheduleByID(int scheduleId)
        {
            Schedule? schedule = await _scheduleRepository.GetScheduleByID(scheduleId);
            ScheduleDto? scheduleDto = null;
            if (schedule != null)
            {
                scheduleDto = new ScheduleDto(schedule);
            }
            return scheduleDto;
        }

        public async Task<List<ScheduleDto>> GetScheduleByBarberID(string barberId)
        {
            var schedules = await _scheduleRepository.GetScheduleByBarberID(barberId);

            var schedulesDtos = from schedule in schedules
                                select new ScheduleDto(schedule);

            return schedulesDtos.ToList();
        }

        public async Task InsertSchedule(ScheduleDto scheduleDto)
        {
            Schedule schedule = scheduleDto.ToEntity();
            await _scheduleRepository.InsertSchedule(schedule);
        }

        public async Task UpdateSchedule(ScheduleDto scheduleDto)
        {
            Schedule schedule = scheduleDto.ToEntity();
            await _scheduleRepository.UpdateSchedule(schedule);
        }
    }
}

using BusinessLogicLayer.DTOs;

namespace BarberLayered.Models
{

    public enum Enum_DayOfWeek
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class Schedule
    {
        public int Id { get; set; }
        public string fk_BarberId { get; set; }
        public Enum_DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public Schedule() 
        {
            Id = 0;
            fk_BarberId = "";
            DayOfWeek = Enum_DayOfWeek.Monday;
            StartTime = new TimeOnly();
            EndTime = new TimeOnly();
        }

        public Schedule(ScheduleDto scheduleDto)
        {
            Id = scheduleDto.Id;
            fk_BarberId = scheduleDto.fk_BarberId;
            DayOfWeek = (Enum_DayOfWeek)scheduleDto.DayOfWeek;
            StartTime = scheduleDto.StartTime;
            EndTime = scheduleDto.EndTime;
        }

        public ScheduleDto ToDto()
        {
            ScheduleDto scheduleDto = new ScheduleDto()
            {
                Id = this.Id,
                fk_BarberId = this.fk_BarberId,
                DayOfWeek = (BusinessLogicLayer.DTOs.Enum_DayOfWeek)this.DayOfWeek,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };
            return scheduleDto;
        }
    }
}
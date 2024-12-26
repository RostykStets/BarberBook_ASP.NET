using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
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

    public class ScheduleDto
    {
        public int Id { get; set; }
        public string fk_BarberId { get; set; }
        public Enum_DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public ScheduleDto() 
        {
            Id = 0;
            fk_BarberId = "";
            DayOfWeek = Enum_DayOfWeek.Monday;
            StartTime = new TimeOnly();
            EndTime = new TimeOnly();
        }

        public ScheduleDto(Schedule schedule)
        {
            Id = schedule.Id;
            fk_BarberId = schedule.fk_BarberId;
            DayOfWeek = (Enum_DayOfWeek)schedule.DayOfWeek;
            StartTime = schedule.StartTime;
            EndTime = schedule.EndTime;
        }

        public Schedule ToEntity()
        {
            Schedule schedule = new Schedule()
            {
                Id = this.Id,
                fk_BarberId = this.fk_BarberId,
                DayOfWeek = (DataAccessLayer.Entities.Enum_DayOfWeek)this.DayOfWeek,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };

            return schedule;
        }
    }
}

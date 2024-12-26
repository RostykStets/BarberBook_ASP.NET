namespace DataAccessLayer.Entities
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
        public required string fk_BarberId { get; set; }
        public Enum_DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}

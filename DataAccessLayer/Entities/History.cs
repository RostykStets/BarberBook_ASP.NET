namespace DataAccessLayer.Entities
{
    public class History
    {
        public int Id { get; set; }
        public required string ClientPhone { get; set; }
        public required string BarberPhone { get; set; }
        public required string Service { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}

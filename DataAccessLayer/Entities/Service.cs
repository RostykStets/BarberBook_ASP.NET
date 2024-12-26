namespace DataAccessLayer.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public required string fk_BarberId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TimeOnly Duration { get; set; }
        public int Price { get; set; }
    }
}

namespace DataAccessLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public required string fk_ClientId { get; set; }
        public required string fk_BarberId { get; set; }
        public string? Text { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }
    }
}

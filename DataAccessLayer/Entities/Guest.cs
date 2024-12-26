namespace DataAccessLayer.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // TODO
        public string? Surname { get; set; }
        public required string Phone { get; set; }
    }
}

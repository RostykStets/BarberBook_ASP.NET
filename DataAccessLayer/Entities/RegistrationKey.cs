namespace DataAccessLayer.Entities
{
    public class RegistrationKey
    {
        public int Id { get; set; }
        public required string Key { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}

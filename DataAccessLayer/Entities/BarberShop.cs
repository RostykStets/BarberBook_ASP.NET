namespace DataAccessLayer.Entities
{
    public class BarberShop
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? PhoneSecond { get; set; }
        public string? Description { get; set; }
        public string? PhotoUri { get; set; }
        public string? SocialUri { get; set; }
        public string? SocialUriSecond { get; set; }
        public string? SocialUriThird { get; set; }
    }
}

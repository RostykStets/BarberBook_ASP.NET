namespace DataAccessLayer.Entities
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Client() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PasswordHash = "";
        }

        public Client(ApplicationUser? applicationUser)
        {
            Id = applicationUser.Id ?? "";
            Name = applicationUser.UserName ?? "";
            Surname = "";
            Phone = applicationUser.PhoneNumber ?? "";
            Email = applicationUser.Email ?? "";
            PasswordHash = applicationUser.PasswordHash ?? "";
        }
    }
}

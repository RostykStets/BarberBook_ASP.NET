using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class AdminDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public AdminDto() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PasswordHash = "";
        }

        public AdminDto(Admin admin)
        {
            Id = admin.Id;
            Name = admin.Name;
            Surname = admin.Surname;
            Phone = admin.Phone;
            Email = admin.Email;
            PasswordHash = admin.PasswordHash;
        }

        public AdminDto(RegistrationDto registrationDto, string hashedPassword)
        {
            Name = registrationDto.Name;
            Surname = registrationDto.Surname;
            Phone = registrationDto.Phone;
            Email = registrationDto.Email;
            PasswordHash = hashedPassword;
        }
    }
}

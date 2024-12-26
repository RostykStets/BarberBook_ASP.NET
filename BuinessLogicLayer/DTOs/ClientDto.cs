using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ClientDto() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PasswordHash = "";
        }

        public ClientDto(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Phone = client.Phone;
            Email = client.Email;
            PasswordHash = client.PasswordHash;
        }

        public ClientDto(RegistrationDto registrationDto, string hashedPassword)
        {
            Name = registrationDto.Name;
            Surname = registrationDto.Surname;
            Phone = registrationDto.Phone;
            Email = registrationDto.Email;
            PasswordHash = hashedPassword;
        }
    }
}

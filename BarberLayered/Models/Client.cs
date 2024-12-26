using BusinessLogicLayer.DTOs;

namespace BarberLayered.Models
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
        public Client(ClientDto clientDto)
        {
            Id = clientDto.Id;
            Name = clientDto.Name;
            Surname = clientDto.Surname;
            Phone = clientDto.Phone;
            Email = clientDto.Email;
            PasswordHash = clientDto.PasswordHash;
        }

        public Client(UserExtDto userExtDto)
        {
            Id = userExtDto.Id;
            Name = userExtDto.Name;
            Surname = userExtDto.Surname;
            Phone = userExtDto.Phone;
            Email = userExtDto.Email;
            PasswordHash = userExtDto.PasswordHash;
        }
    }
}
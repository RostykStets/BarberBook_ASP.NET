using System.Diagnostics.CodeAnalysis;
using BusinessLogicLayer.DTOs;

namespace BarberLayered.Models
{
    public class Admin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public Admin() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PasswordHash = "";
        }
        public Admin(AdminDto adminDto)
        {
            Id = adminDto.Id;
            Name = adminDto.Name;
            Surname = adminDto.Surname;
            Phone = adminDto.Phone;
            Email = adminDto.Email;
            PasswordHash = adminDto.PasswordHash;
        }
        public Admin(UserExtDto userExtDto)
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
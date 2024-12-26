using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Identity;

namespace BarberLayered.Models
{
    public class Barber
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? PhotoUri { get; set; } 
        public string? Description { get; set; }
        public string? PortfolioUri { get; set; } 

        public Barber() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PhotoUri = "";
            Description = "";
            PortfolioUri = "";
        }
        public Barber(BarberDto barberDto)
        {
            Id = barberDto.Id;
            Name = barberDto.Name;
            Surname = barberDto.Surname;
            Phone = barberDto.Phone;
            Email = barberDto.Email;
            PhotoUri = barberDto.PhotoUri;
            Description = barberDto.Description;
            PortfolioUri = barberDto.PortfolioUri;
        }

        public Barber(UserExtDto userExtDto)
        {
            Id = userExtDto.Id;
            Name = userExtDto.Name;
            Surname = userExtDto.Surname;
            Phone = userExtDto.Phone;
            Email = userExtDto.Email;
            PhotoUri = userExtDto.PhotoUri;
            Description = userExtDto.Description;
            PortfolioUri = userExtDto.PortfolioUri;
        }
    }
}

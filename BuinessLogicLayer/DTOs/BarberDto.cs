using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class BarberDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? PhotoUri { get; set; }
        public string? Description { get; set; }
        public string? PortfolioUri { get; set; }

        public BarberDto() 
        {
            Id = "";
            Name = "";
            Surname = "";
            Phone = "";
            Email = "";
            PasswordHash = "";
            PhotoUri = "";
            Description = "";
            PortfolioUri = "";
        }

        public BarberDto(Barber barber)
        {
            Id = barber.Id;
            Name = barber.Name;
            Surname = barber.Surname;
            Phone = barber.Phone;
            Email = barber.Email;
            PasswordHash = barber.PasswordHash;
            PhotoUri = barber.PhotoUri;
            Description = barber.Description;
            PortfolioUri = barber.PortfolioUri;
        }

        public BarberDto(RegistrationDto registrationDto, string hashedPassword)
        {
            Name = registrationDto.Name;
            Surname = registrationDto.Surname;
            Phone = registrationDto.Phone;
            Email = registrationDto.Email;
            PasswordHash = hashedPassword;
        }
    }
}

using System.Security.Policy;

namespace BusinessLogicLayer.DTOs
{
    public enum _UserType
    {
        Admin = 1,
        Barber,
        Client,
    }

    public class UserExtDto
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
        public _UserType UserType { get; set; }
        public string ErrorMsg {  get; set; }

        public UserExtDto() { ErrorMsg = ""; }
        public UserExtDto(AdminDto adminDto)
        {
            Id = adminDto.Id;
            Name = adminDto.Name;
            Surname = adminDto.Surname;
            Phone = adminDto.Phone;
            Email = adminDto.Email;
            PasswordHash = adminDto.PasswordHash;
            UserType = _UserType.Admin;
            ErrorMsg = "";
        }
        public UserExtDto(BarberDto barberDto)
        {
            Id = barberDto.Id;
            Name = barberDto.Name;
            Surname = barberDto.Surname;
            Phone = barberDto.Phone;
            Email = barberDto.Email;
            PasswordHash = barberDto.PasswordHash;
            PhotoUri = barberDto.PhotoUri;
            Description = barberDto.Description;
            PortfolioUri = barberDto.PortfolioUri;
            UserType = _UserType.Barber;
            ErrorMsg = "";
        }
        public UserExtDto(ClientDto clientDto) 
        {
            Id = clientDto.Id;
            Name = clientDto.Name;
            Surname = clientDto.Surname;
            Phone = clientDto.Phone;
            Email = clientDto.Email;
            PasswordHash = clientDto.PasswordHash;
            UserType = _UserType.Client;
            ErrorMsg = "";
        }
    }
}

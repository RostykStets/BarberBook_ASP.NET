namespace BusinessLogicLayer.DTOs
{
    public class RegistrationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public _UserType UserType { get; set; }
        public string RegistrationKey { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BarberLayered.Models
{
    public class RegisterViewModelWithKey : RegisterViewModel
    {
        [Display(Name = "Registration Key")]
        public string RegistrationKey { get; set; }
    }
}

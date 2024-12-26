namespace BarberLayered.Models
{
    public class AppointmentViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int SelectedBarberId { get; set; }
        public int SelectedServiceId { get; set; }
        public string SelectedDay { get; set; }
        public string SelectedTime { get; set; }

    }
}
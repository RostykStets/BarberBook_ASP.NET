using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class GuestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Phone { get; set; }

        public GuestDto() 
        {
            Id = 0;
            Name = "";
            Surname = "";
            Phone = "";
        }

        public GuestDto(Guest guest)
        {
            Id = guest.Id;
            Name = guest.Name;
            Surname = guest.Surname;
            Phone = guest.Phone;
        }

        public Guest ToEntity()
        {
            Guest guest = new Guest()
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                Phone = this.Phone
            };

            return guest;
        }
    }
}

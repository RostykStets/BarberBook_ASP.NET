using BusinessLogicLayer.DTOs;

namespace BarberLayered.Models
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? PhoneSecond { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public string? PhotoUri { get; set; }

        public BarberShop() 
        {
            Id = 0;
            Name = "";
            Address = "";
            Phone = "";
            PhoneSecond = null;
            Description = "";
            PhotoUri = "";
        }

        public BarberShop(BarberShopDto barberShopDto)
        {
            Id = barberShopDto.Id;
            Name = barberShopDto.Name;
            Phone = barberShopDto.Phone;
            PhoneSecond = barberShopDto.PhoneSecond;
            Address = barberShopDto.Address;
            Description = barberShopDto.Description;
            PhotoUri = barberShopDto.PhotoUri;
        }
    }
}

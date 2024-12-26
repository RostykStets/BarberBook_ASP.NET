using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BarberLayered.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string fk_BarberId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TimeOnly Duration { get; set; }
        public int Price { get; set; }

        public Service()
        {
            Id = 0;
            fk_BarberId = "";
            Title = "";
            Description = "";
            Duration = new TimeOnly();
            Price = 0;
        }

        public Service(ServiceDto serviceDto)
        {
            Id = serviceDto.Id;
            fk_BarberId = serviceDto.fk_BarberId;
            Title = serviceDto.Title;
            Description = serviceDto.Description;
            Duration = serviceDto.Duration;
            Price = serviceDto.Price;
        }

        public ServiceDto ToDto()
        {
            ServiceDto serviceDto = new ServiceDto()
            {
                Id = this.Id,
                fk_BarberId = this.fk_BarberId,
                Title = this.Title,
                Description = this.Description,
                Duration = this.Duration,
                Price = this.Price,
            };

            return serviceDto;
        }
    }
}

using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string fk_BarberId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TimeOnly Duration { get; set; }
        public int Price { get; set; }

        public ServiceDto() 
        {
            Id = 0;
            fk_BarberId = "";
            Title = "";
            Description = "";
            Duration = new TimeOnly();
            Price = 0;
        }

        public ServiceDto(Service service)
        {
            Id = service.Id;
            fk_BarberId = service.fk_BarberId;
            Title = service.Title;
            Description = service.Description;
            Duration = service.Duration;
            Price = service.Price;
        }

        public Service ToEntity()
        {
            Service service = new Service()
            {
                Id = this.Id,
                fk_BarberId = this.fk_BarberId,
                Title = this.Title,
                Description = this.Description,
                Duration = this.Duration,
                Price = this.Price
            };

            return service;
        }
    }
}

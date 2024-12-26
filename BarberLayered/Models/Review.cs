using BusinessLogicLayer.DTOs;

namespace BarberLayered.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string fk_ClientId { get; set; }
        public string fk_BarberId { get; set; }
        public string? Text { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }

        public Review()
        {
            Id = 0;
            fk_ClientId = "";
            fk_BarberId = "";
            Text = "";
            Rating = 0;
            Date = DateTime.Now;
        }

        public Review(ReviewDto reviewDto)
        {
            Id = reviewDto.Id;
            fk_ClientId = reviewDto.fk_ClientId;
            fk_BarberId = reviewDto.fk_BarberId;
            Text = reviewDto.Text;
            Rating = reviewDto.Rating;
            Date = reviewDto.Date;
        }

        public ReviewDto ToDto()
        {
            ReviewDto reviewDto = new ReviewDto()
            {
                Id = this.Id,
                fk_ClientId = this.fk_ClientId,
                fk_BarberId = this.fk_BarberId,
                Text = this.Text,
                Rating = this.Rating,
                Date = this.Date
            };

            return reviewDto;
        }
    }
}

using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string fk_ClientId { get; set; }
        public string fk_BarberId { get; set; }
        public string? Text { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }

        public ReviewDto() 
        {
            Id = 0;
            fk_ClientId = "";
            fk_BarberId = "";
            Text = "";
            Rating = 0;
            Date = DateTime.Now;
        }

        public ReviewDto(Review review)
        {
            Id = review.Id;
            fk_ClientId = review.fk_ClientId;
            fk_BarberId = review.fk_BarberId;
            Text = review.Text;
            Rating = review.Rating;
            Date = review.Date;
        }

        public Review ToEntity()
        {
            Review review = new Review()
            {
                Id = this.Id,
                fk_ClientId = this.fk_ClientId,
                fk_BarberId = this.fk_BarberId,
                Text = this.Text,
                Rating = this.Rating,
                Date = this.Date,
            };

            return review;
        }
    }
}

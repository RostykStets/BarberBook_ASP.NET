using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviews();
        Task<Review?> GetReviewByID(int reviewId);
        Task<IEnumerable<Review>> GetReviewsByBarberId(string fkBarberId);
        Task<IEnumerable<Review>> GetReviewsByClientId(string fkClientId);
        Task InsertReview(Review review);
        Task DeleteReview(int reviewId);
        Task UpdateReview(Review review);
        Task Save();
    }
}

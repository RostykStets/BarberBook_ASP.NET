using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetReviews();
        Task<List<ReviewDto>> GetReviewsByBarberId(string fkBarberId);
        Task<List<ReviewDto>> GetReviewsByClientId(string fkClientId);
        Task<ReviewDto?> GetReviewByID(int reviewId);
        Task InsertReview(ReviewDto reviewDto);
        Task DeleteReview(int reviewId);
        Task UpdateReview(ReviewDto reviewDto);
    }
}

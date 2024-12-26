using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewDto>> GetReviews()
        {
            var reviews = await _reviewRepository.GetReviews();
            var reviewsDtos = from review in reviews
                              select new ReviewDto(review);
            return reviewsDtos.ToList();
        }

        public async Task<ReviewDto?> GetReviewByID(int reviewId)
        {
            Review? review = await _reviewRepository.GetReviewByID(reviewId);
            ReviewDto? reviewDto = null;
            if (review != null)
            {
                reviewDto = new ReviewDto(review);
            }
            return reviewDto;
        }


        public async Task<List<ReviewDto>> GetReviewsByBarberId(string fkBarberId)
        {
            var reviews = await _reviewRepository.GetReviewsByBarberId(fkBarberId);
            var reviewsDtos = from review in reviews
                              select new ReviewDto(review);
            return reviewsDtos.ToList();
        }

        public async Task<List<ReviewDto>> GetReviewsByClientId(string fkClientId)
        {
            var reviews = await _reviewRepository.GetReviewsByClientId(fkClientId);
            var reviewsDtos = from review in reviews
                              select new ReviewDto(review);

            return reviewsDtos.ToList();
        }

        public async Task InsertReview(ReviewDto reviewDto)
        {
            Review review = reviewDto.ToEntity();
            await _reviewRepository.InsertReview(review);
        }

        public async Task UpdateReview(ReviewDto reviewDto)
        {
            Review review = reviewDto.ToEntity();
            await _reviewRepository.UpdateReview(review);
        }
        public async Task DeleteReview(int reviewId)
        {
            await _reviewRepository.DeleteReview(reviewId);
        }
    }
}

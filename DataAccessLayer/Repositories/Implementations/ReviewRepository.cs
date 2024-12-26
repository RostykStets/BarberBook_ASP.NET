using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetReviewByID(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        public async Task<IEnumerable<Review>> GetReviewsByBarberId(string fkBarberId)
        {
            return await _context.Reviews.Where(x => x.fk_BarberId == fkBarberId).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByClientId(string fkClientId)
        {
            return await _context.Reviews.Where(x => x.fk_ClientId == fkClientId).ToListAsync();
        }

        public async Task InsertReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await Save();
        }

        public async Task DeleteReview(int reviewId)
        {
            Review? review = await _context.Reviews.FindAsync(reviewId);
            if (null != review) _context.Reviews.Remove(review);
            await Save();
        }

        public async Task UpdateReview(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

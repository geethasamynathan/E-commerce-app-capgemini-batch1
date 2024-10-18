using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Service
{
    public class ReviewService:IReviewService
    {

        private readonly EcommerceContext _context;

        public ReviewService(EcommerceContext context)
        {
            _context = context;
        }

        public async Task AddReview(int? productId, Review review)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            review.ProductId = productId;
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductId(int productId)
        {
            return await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserId(int userId)
        {
            return await _context.Reviews.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}

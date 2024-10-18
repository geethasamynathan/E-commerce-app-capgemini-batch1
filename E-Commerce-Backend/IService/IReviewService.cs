using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IService
{
    public interface IReviewService
    {
        Task AddReview(int? productId, Review review);
        Task<IEnumerable<Review>> GetReviews();
        Task<Review> GetReviewById(int id);
        Task<IEnumerable<Review>> GetReviewsByProductId(int productId);
        Task<IEnumerable<Review>> GetReviewsByUserId(int userId);

    }
}

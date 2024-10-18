using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewsController> _logger;


        public ReviewsController(IReviewService reviewService, ILogger<ReviewsController> logger, IMapper mapper)
        {
            _reviewService = reviewService;
            _logger = logger;
            _mapper = mapper;
        }

        // POST /api/reviews - Add a new review for a product.
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewDto)
        {
            try
            {
                var review = _mapper.Map<Review>(reviewDto);
                await _reviewService.AddReview(reviewDto.ProductId, review);
                var createdReviewDto = _mapper.Map<ReviewDTO>(review);
                return CreatedAtAction(nameof(GetReviewById), new { id = review.ReviewId }, createdReviewDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // GET /api/reviews - List all reviews.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews()
        {
            var reviews = await _reviewService.GetReviews();
            if (reviews != null)
            {
                var reviewDTOs = _mapper.Map<List<ReviewDTO>>(reviews);
                return Ok(reviewDTOs);
            }
            else
            {
                return NotFound();
            }
        }

        // GET /api/reviews/{id} - View details of a specific review.
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewById(id)



  ;
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // GET /api/reviews/product/{productId} - List reviews for a specific product.
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByProductId(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductId(productId);
            return Ok(reviews);
        }

        // GET /api/reviews/user/{userId} - List reviews made by a specific user.
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByUserId(int userId)
        {
            var reviews = await _reviewService.GetReviewsByUserId(userId);
            return Ok(reviews);
        }
    }
}

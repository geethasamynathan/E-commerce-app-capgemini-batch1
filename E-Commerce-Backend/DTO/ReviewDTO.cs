namespace E_Commerce_Backend.DTO
{
    public class ReviewDTO
    {
        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public decimal? Rating { get; set; }

        public string? Comment { get; set; }

    }
}

namespace E_commerce_frontend.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public decimal? Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime? ReviewDate { get; set; }

        public virtual Product? Product { get; set; }

        public virtual User? User { get; set; }
    }
}

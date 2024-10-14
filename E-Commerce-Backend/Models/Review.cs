﻿namespace E_Commerce_Backend.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public decimal? Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime? ReviewDate { get; set; }

        public  Product? Product { get; set; }

        public  User? User { get; set; }
    }
}

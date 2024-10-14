namespace E_Commerce_Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public Product Product { get; set; } = null!;

        public  User User { get; set; } = null!;
        public bool IsReturned { get; internal set; }
    }
}

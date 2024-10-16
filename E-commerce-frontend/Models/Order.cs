namespace E_commerce_frontend.Models
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

        public virtual Product Product { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}

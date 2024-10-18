namespace E_Commerce_Backend.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}

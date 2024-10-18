using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Service
{
    public class OrderService:IOrderService
    {
        private readonly EcommerceContext _context;
        public OrderService(EcommerceContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<Order> GetByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId);
        }

        public IEnumerable<Order> GetByStatus(string status)
        {
            var orders = _context.Orders
                        .AsEnumerable()
                        .Where(o => o.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                        .ToList();
            return orders;
        }

        public void Add(Order order)
        {
            order.TotalAmount = TotalPrice(order.OrderId);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public Order Update(Order order)
        {
            var existingOrder = GetById(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.UserId = order.UserId;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.Status = order.Status;
                existingOrder.TotalAmount = order.TotalAmount;
                // _context.Orders.Add(existingOrder);
                _context.SaveChanges();
                return existingOrder;
            }
            return null;
        }

        public void Delete(int id)
        {
            var order = GetById(id)

    ;
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public decimal TotalPrice(int orderId)
        {
            var totalPrice = (from order in _context.Orders
                              join product in _context.Products on order.ProductId equals product.ProductId
                              where order.OrderId == orderId
                              select order.Quantity * product.Price).Sum();
            return totalPrice;
        }
    }
}

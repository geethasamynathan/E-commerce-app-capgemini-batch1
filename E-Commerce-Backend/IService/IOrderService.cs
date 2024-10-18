using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IService
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        IEnumerable<Order> GetByUserId(int userId);
        IEnumerable<Order> GetByStatus(string status);
        void Add(Order order);
        Order Update(Order order);
        void Delete(int id);
        decimal TotalPrice(int orderId);
    }
}

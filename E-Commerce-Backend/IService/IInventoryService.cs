using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IService
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAll();
        Inventory GetById(int id);
        Task<Inventory> GetByProductId(int productId);
        void Add(Inventory inventory);
        void Update(Inventory inventory);
        string Delete(int id);
    }
}

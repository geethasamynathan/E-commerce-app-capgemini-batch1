using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Service
{
    public class InventoryService: IInventoryService
    {
        private readonly EcommerceContext _context;

        public InventoryService(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _context.Inventories.ToListAsync();
        }

        public Inventory GetById(int id)
        {
            return _context.Inventories.FirstOrDefault(i => i.InventoryId == id);
        }

        public async Task<Inventory> GetByProductId(int productId)
        {
            return await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public void Add(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
        }

        public void Update(Inventory inventory)
        {
            var existingInventory = GetById(inventory.InventoryId);
            if (existingInventory != null)
            {
                existingInventory.InventoryId = inventory.InventoryId;
                existingInventory.StockQuantity = inventory.StockQuantity;
            }
        }
        public string Delete(int id)
        {
            var inventory = GetById(id)
    ;
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                return "Removed";
            }
            return "Not Found";
        }
    }
}

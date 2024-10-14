using System;
using System.Collections.Generic;

namespace E_Commerce_Backend.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int StockQuantity { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual Product Product { get; set; } = null!;
}

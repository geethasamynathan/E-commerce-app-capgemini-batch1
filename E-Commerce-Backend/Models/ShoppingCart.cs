﻿using System;
using System.Collections.Generic;

namespace E_Commerce_Backend.Models;

public partial class ShoppingCart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public int? ProductId { get; set; }

    public decimal? TotalAmount { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User User { get; set; } = null!;
}

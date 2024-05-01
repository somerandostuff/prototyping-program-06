using System;
using System.Collections.Generic;

namespace Assignment_2_NEW.Models;

public partial class Cart
{
    public int CartId { get; set; }

    // public string CustomerId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    // public string? CartDetail { get; set; }

    // public DateTime? OrderCreation { get; set; }

    public virtual Product Product { get; set; } = null!;
}

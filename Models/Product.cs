using System;
using System.Collections.Generic;

namespace Assignment_2_NEW.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? ProductDesc { get; set; }

    public string CategoryId { get; set; } = null!;
    public int Price { get; set; } = 0!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;
}

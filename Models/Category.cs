using System;
using System.Collections.Generic;

namespace Assignment_2_NEW.Models;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string? CategoryName { get; set; }

    public string? CategoryDesc { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

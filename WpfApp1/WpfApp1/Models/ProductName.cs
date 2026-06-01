using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class ProductName
{
    public int ProductNameId { get; set; }

    public string? ProductType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

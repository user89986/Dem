using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class DetailOrder
{
    public int DetailOrdersId { get; set; }

    public int? OrdersId { get; set; }

    public string? ProductsId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Orders { get; set; }

    public virtual Product? Products { get; set; }
}

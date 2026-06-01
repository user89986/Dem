using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Creater
{
    public int CreaterId { get; set; }

    public string? CreaterName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

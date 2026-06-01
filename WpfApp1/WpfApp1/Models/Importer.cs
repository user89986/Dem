using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Importer
{
    public int ImporterId { get; set; }

    public string? ImporterName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

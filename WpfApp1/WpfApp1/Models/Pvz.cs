using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Pvz
{
    public int Pvzid { get; set; }

    public string? Pvzname { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

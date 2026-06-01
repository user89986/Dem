using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class StatusName
{
    public int StatusNameId { get; set; }

    public string? StatusType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

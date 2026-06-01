using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class Order
{
    public int OrdersId { get; set; }

    public DateOnly? DateOrder { get; set; }

    public DateOnly? DateDevilery { get; set; }

    public int? Pvzid { get; set; }

    public int? UserId { get; set; }

    public int? Code { get; set; }

    public int? StatusNameId { get; set; }

    public virtual ICollection<DetailOrder> DetailOrders { get; set; } = new List<DetailOrder>();

    public virtual Pvz? Pvz { get; set; }

    public virtual StatusName? StatusName { get; set; }

    public virtual User? User { get; set; }
}

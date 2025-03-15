using System;
using System.Collections.Generic;

namespace LorKingDom_Management_System.Models;

public partial class ShippingMethod
{
    public int ShippingMethodId { get; set; }

    public string MethodName { get; set; } = null!;

    public DateOnly? DeliveryDate { get; set; }

    public DateOnly? DateTo { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

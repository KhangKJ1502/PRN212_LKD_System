using System;
using System.Collections.Generic;

namespace LorKingDom_Management_System.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Material { get; set; }

    public int MinAge { get; set; }

    public decimal Price { get; set; }

    public int? Quantity { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

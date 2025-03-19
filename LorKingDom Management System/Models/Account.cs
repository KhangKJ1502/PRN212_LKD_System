using System;
using System.Collections.Generic;

namespace LorKingDom_Management_System.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string AccountName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Address { get; set; }

    public int RoleId { get; set; }

    public int IsDeleted { get; set; }

    public string Status { get; set; } = null!;

    public decimal Balance { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace StoreApplication35.Models;

public partial class User
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

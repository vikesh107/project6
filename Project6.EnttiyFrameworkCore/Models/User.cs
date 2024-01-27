using System;
using System.Collections.Generic;

namespace Project6.EnttiyFrameworkCore.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Customerinterest> Customerinterests { get; } = new List<Customerinterest>();

    public virtual ICollection<Productrating> Productratings { get; } = new List<Productrating>();
}

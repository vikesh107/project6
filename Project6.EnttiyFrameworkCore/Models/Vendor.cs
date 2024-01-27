using System;
using System.Collections.Generic;

namespace Project6.EnttiyFrameworkCore.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? ContactDetails { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}

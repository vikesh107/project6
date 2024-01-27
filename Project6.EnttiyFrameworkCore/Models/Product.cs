using System;
using System.Collections.Generic;

namespace Project6.EnttiyFrameworkCore.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public int? VendorId { get; set; }

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Customerinterest> Customerinterests { get; } = new List<Customerinterest>();

    public virtual ICollection<Productrating> Productratings { get; } = new List<Productrating>();

    public virtual Vendor? Vendor { get; set; }
}

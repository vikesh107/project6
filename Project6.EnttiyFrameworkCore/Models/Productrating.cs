using System;
using System.Collections.Generic;

namespace Project6.EnttiyFrameworkCore.Models;

public partial class Productrating
{
    public int RatingId { get; set; }

    public int? ProductId { get; set; }

    public int? CustomerId { get; set; }

    public int? Rating { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Product? Product { get; set; }
}

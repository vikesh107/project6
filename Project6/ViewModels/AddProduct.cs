using Project6.EnttiyFrameworkCore.Models;

namespace Project6.ViewModels
{
    public class AddProduct
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? CategoryId { get; set; }

        public int? VendorId { get; set; }

        public decimal? Price { get; set; }

        public string? ImageUrl { get; set; }

    }
}

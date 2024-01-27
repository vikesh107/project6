using Microsoft.AspNetCore.Mvc;
using Project6.EnttiyFrameworkCore.Models;
using Project6.ViewModels;

namespace Project6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = from product in _context.Products
                           join vendor in _context.Vendors
                           on product.VendorId equals vendor.VendorId 
                           where vendor.IsActive == true
                           select new
                           {
                               Name = product.ProductName,
                               Price = product.Price,
                               Image = product.ImageUrl,
                               category = product.Category.CategoryName,
                               Reating = product.Productratings.Any() ? (decimal)product.Productratings.Sum(x => x.Rating) / product.Productratings.Count : 0,
                           };
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductDetails([FromRoute] int id)
        {
           
            var data = (from product in _context.Products
                       join vendor in _context.Vendors
                       on product.VendorId equals vendor.VendorId
                       where product.ProductId == id && vendor.IsActive == true
                       select new { 
                       Name = product.ProductName,
                       Price = product.Price,
                       Image = product.ImageUrl,
                       category = product.Category.CategoryName,
                       Reating = product.Productratings.Any() ? (decimal)product.Productratings.Sum(x=>x.Rating)/product.Productratings.Count : 0,
                       VendorName = vendor.VendorName,
                       VendorDetails = vendor.ContactDetails
                       }).FirstOrDefault();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProduct product)
        {
            var Product = new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                VendorId = product.VendorId,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
            };
            _context.Products.Add(Product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("IsProductInterested/{customerId}")]
        public IActionResult IsProductInterested([FromRoute] int customerId)
        {
            var data = from cinterest in _context.Customerinterests                   
                       join product in _context.Products
                       on cinterest.ProductId equals product.ProductId
                       where cinterest.CustomerId == customerId
                       select new {
                           Name = product.ProductName,
                           Price = product.Price,
                           Image = product.ImageUrl,
                           category = product.Category.CategoryName,
                           Reating = product.Productratings.Any() ? (decimal)product.Productratings.Sum(x => x.Rating) / product.Productratings.Count : 0,
                       };
            return Ok(data);
        }
    }
}

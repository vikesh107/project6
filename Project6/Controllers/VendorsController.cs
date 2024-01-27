using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project6.EnttiyFrameworkCore.Models;

namespace Project6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public VendorsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVendors()
        {
            var vendors = _context.Vendors.ToList();
            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorDetails([FromRoute] int id)
        {
            //var vendor = _context.Vendors.Include(v => v.Products).FirstOrDefault(v => v.VendorId == id);
            var data = from vendor in _context.Vendors
                       join product in _context.Products
                       on vendor.VendorId equals product.VendorId
                       where vendor.VendorId == id
                       group product by new { vendor.VendorName, vendor.ContactDetails } into vendorGroup
                       select new
                       {
                           VendorName = vendorGroup.Key.VendorName,
                           Details = vendorGroup.Key.ContactDetails,
                           Products = vendorGroup.Select(p => p.ProductName).ToList()
                       };

            return Ok(data.FirstOrDefault());
        }
    }
}

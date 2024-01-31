using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project6.EnttiyFrameworkCore.Models;
using System.Data;
using System.Security.Claims;

namespace Project6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MyDbContext _context;
        

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Customers")]
        public IActionResult GetCustomers()
        {
            var customers = _context.Users.Where(u => u.Role == "Customer").ToList();
            return Ok(customers);
        }

        [HttpGet("Customers/{id}")]
        public IActionResult GetCustomerDetails([FromRoute] int id)
        {
            var customer = _context.Users.FirstOrDefault(u => u.UserId == id && u.Role == "Customer");
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost("Customers/Deactivate/{id}")]
        public IActionResult DeactivateCustomer([FromRoute] int id)
        {
            var customer = _context.Users.FirstOrDefault(u => u.UserId == id && u.Role == "Customer");
            if (customer == null)
            {
                return NotFound();
            }

            customer.IsActive = false;
            _context.SaveChanges();

            return Ok(customer);
        }
        [HttpPost("Vendors/Deactivate/{id}")]
        public IActionResult DeactivateVendor([FromRoute] int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(u => u.VendorId == id);
            if (vendor == null)
            {
                return NotFound();
            }

            vendor.IsActive = false;
            _context.SaveChanges();

            return Ok(vendor);
        }

        [HttpGet("InspectClaims")]
        public IActionResult InspectClaims()
        {
            var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            return Ok(new { Roles = roles });
        }
    }
}

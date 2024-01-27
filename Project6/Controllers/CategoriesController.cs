using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project6.EnttiyFrameworkCore.Models;
namespace Project6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoriesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpGet("byCatagory/{cat}")]
        public IActionResult CatageoryWise([FromRoute] string cat) {
            var result = from catageory in _context.Categories
                         join product in _context.Products
                         on catageory.CategoryId equals product.CategoryId
                         where catageory.CategoryName == cat
                         group product by new { catageory.CategoryName} into g
                         select new
                         {
                             ProducName = g.Key.CategoryName,
                             ListOfProduct  = g.Select(p=>p.ProductName)
                         };
            return Ok(result);
        }

    }
}

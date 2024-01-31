using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project6.EnttiyFrameworkCore.Models;
using Project6.ViewModels;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AuthController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterModel model)
        {
            // Check if the username is already taken
            if (_context.Users.Any(u => u.Username == model.Username))
            {
                return BadRequest(new { Message = "Username is already taken" });
            }

            var newUser = new User
            {
                Username = model.Username,
                Password = model.Password,
                Role = "Customer"
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel model)
        {
            // Find the user by username and password
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            // Assume successful login, generate JWT token
            var token = GenerateJwtToken1(user);

            return Ok(new { Token = token });
        }


        private string GenerateJwtToken1(User user)
        {
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.Username),
               new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Set the token expiration time
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vikesh123@12345678901234567890ABCD")), SecurityAlgorithms.HmacSha256),
                audience: "https://localhost:44396",
                issuer: "https://localhost:44396"
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

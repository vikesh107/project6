using System.ComponentModel.DataAnnotations;

namespace Project6.ViewModels
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

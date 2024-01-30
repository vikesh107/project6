using System.ComponentModel.DataAnnotations;

namespace Project6.ViewModels
{
    public class UserRegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

    }
}

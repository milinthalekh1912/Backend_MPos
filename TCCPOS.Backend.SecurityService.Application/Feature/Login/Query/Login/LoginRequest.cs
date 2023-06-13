
using System.ComponentModel.DataAnnotations;


namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.Login
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}

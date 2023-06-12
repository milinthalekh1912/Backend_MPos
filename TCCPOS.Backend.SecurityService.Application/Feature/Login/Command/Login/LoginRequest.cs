using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Login.Command.Login
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string POSClientID { get; set; } = null!;
        [Required]
        public string Version { get; set; } = null!;
    }
}

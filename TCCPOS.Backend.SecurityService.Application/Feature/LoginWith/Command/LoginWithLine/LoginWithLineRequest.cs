using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWithLine.Command.LoginWithLine
{
    public class LoginWithLineRequest
    {
        [Required]
        public string UserID { get; set; } = null!;
    }
}

using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWithLine.Command.LoginWithLine
{
    public class LoginWithLineCommand : IRequest<LoginWithLineResult>
    {
        public string LoginID { get; set; } = null!;
        /*public string Password { get; set; } = null!;
        public string POSClientID { get; set; } = null!;
        public string Version { get; set; } = null!;*/
        public string ConfigJWTValidIssuer { get; set; } = null!;
        public string ConfigJWTValidAudience { get; set; } = null!;
        public string ConfigJWTSecret { get; set; } = null!;
    }
}

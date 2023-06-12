using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Login.Command.Login
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string POSClientID { get; set; } = null!;
        public string Version { get; set; } = null!;

        public string ConfigJWTValidIssuer { get; set; } = null!;
        public string ConfigJWTValidAudience { get; set; } = null!;
        public string ConfigJWTSecret { get; set; } = null!;
    }
}

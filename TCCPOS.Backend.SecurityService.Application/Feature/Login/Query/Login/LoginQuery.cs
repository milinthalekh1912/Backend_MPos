using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.Login
{
    public class LoginQuery : IRequest<LoginResult>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.LoginEmployee
{
    public class LoginEmployeeQuery : IRequest<LoginEmployeeResult>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

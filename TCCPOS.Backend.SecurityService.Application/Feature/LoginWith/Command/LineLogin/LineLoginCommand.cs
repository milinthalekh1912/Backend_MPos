using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLogin
{
    public class LineLoginCommand : IRequest<LineLoginResult>
    {
        public string accessToken { set; get; }
    }
}

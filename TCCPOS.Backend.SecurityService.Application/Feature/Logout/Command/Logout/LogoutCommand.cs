using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Logout.Command.Logout
{
    public class LogoutCommand : IRequest<LogoutResult>
    {
        public string Username { get; set; } = null!;
        public string POSClientID { get; set; } = null!;

        public LogoutCommand(string username, string posclientid)
        {
            Username = username;
            POSClientID = posclientid;
        }
    }
}

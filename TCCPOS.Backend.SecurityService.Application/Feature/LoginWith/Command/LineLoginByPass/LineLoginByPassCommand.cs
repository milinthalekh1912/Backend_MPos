using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLoginByPass
{
    public class LineLoginByPassCommand : IRequest<LineLoginByPassResult>
    {
        public string SubID { set; get; }
        public LineLoginByPassCommand(LineLoginByPassRequest request)
        {
            SubID = request.subId;
        }
    }
}

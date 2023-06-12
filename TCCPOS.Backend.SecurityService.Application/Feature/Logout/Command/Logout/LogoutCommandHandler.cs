using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.SecurityService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Logout.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResult>
    {
        private readonly ILogger<LogoutCommandHandler> _logger;
        ISecurityRepository _repo;

        public LogoutCommandHandler(ILogger<LogoutCommandHandler> logger, ISecurityRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<LogoutResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var dtnow = DateTime.Now;

            var acc = await _repo.GetUserAccountByLogin(request.Username);
            var userlogin = await _repo.GetUserLoginByKey(acc.UserID, request.POSClientID);

            userlogin.LastLogout = dtnow;
            await _repo.CreateUserActivity(acc.UserID, request.POSClientID, null, "Logout", "", dtnow); // TODO: ถ้ามี shift อยู่แล้วให้เอามาใส่เพิ่ม
            await _repo.SaveChangeAsyncWithCommit();

            var res = new LogoutResult();
            return res;
        }



    }
}

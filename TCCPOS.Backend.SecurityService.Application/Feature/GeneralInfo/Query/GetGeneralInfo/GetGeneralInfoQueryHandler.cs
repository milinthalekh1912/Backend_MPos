using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.SecurityService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.GeneralInfo.Query.GetGeneralInfo
{
    public class GetGeneralInfoQueryHandler : IRequestHandler<GetGeneralInfoQuery, GeneralInfoResult>
    {
        private readonly ILogger<GetGeneralInfoQueryHandler> _logger;
        ISecurityRepository _repo;

        public GetGeneralInfoQueryHandler(ILogger<GetGeneralInfoQueryHandler> logger, ISecurityRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GeneralInfoResult> Handle(GetGeneralInfoQuery request, CancellationToken cancellationToken)
        {
            await Task.FromResult(0); // empty await
            var res = new GeneralInfoResult();
            res.Info = "test info";
            return res;
        }
    }
}

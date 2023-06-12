using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.SecurityService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.CheckVersion.Query.GetCheckVersion
{
    public class GetCheckVersionQueryHandler : IRequestHandler<GetCheckVersionQuery, CheckVersionResult>
    {
        private readonly ILogger<GetCheckVersionQueryHandler> _logger;
        ISecurityRepository _repo;

        public GetCheckVersionQueryHandler(ILogger<GetCheckVersionQueryHandler> logger, ISecurityRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<CheckVersionResult> Handle(GetCheckVersionQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetCurrentVersion();
        }
    }
}

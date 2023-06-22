using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Target.Query.GetTarget
{
    public class GetTargetQueryHandler : IRequestHandler<GetTargetQuery, List<TargetResult>>
    {
        private readonly ILogger<GetTargetQueryHandler> _logger;
        private readonly IInventoryRepository _repo;

        public GetTargetQueryHandler(ILogger<GetTargetQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<TargetResult>> Handle(GetTargetQuery request, CancellationToken cancellationToken)
        {

            var res = await _repo.Target.GetTarget(); 
            res = res.OrderBy(x => x.StartDate).ToList();
            return res.ToList();

        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.PriceTier.Query.GetAllPriceTierGroup
{
    public class GetAllPriceTierGroupQueryHandler : IRequestHandler<GetAllPriceTierGroupQuery, GetAllPriceTierGroupResult>
    {
        private readonly ILogger<GetAllPriceTierGroupQueryHandler> _logger;
        private readonly IInventoryRepository _repo;

        public GetAllPriceTierGroupQueryHandler(ILogger<GetAllPriceTierGroupQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetAllPriceTierGroupResult> Handle(GetAllPriceTierGroupQuery request, CancellationToken cancellationToken)
        {
            var res = new GetAllPriceTierGroupResult();
            var query = await _repo.PriceTier.GetAllPriceTierBySupplierID(request.SupplierID);
            foreach(var element in query)
            {
                GetAllPriceTierGroupItemResult item = new GetAllPriceTierGroupItemResult();
                item.price_tier_id = element.id;
                item.title = element.price_tier_title;
                item.description = element.description;
                res.items.Add(item);
            }
            res.items = res.items.OrderBy(x => x.title).ToList();
            return res;

        }
    }
}

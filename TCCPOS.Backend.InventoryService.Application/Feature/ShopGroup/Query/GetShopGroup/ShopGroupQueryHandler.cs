using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.ShopGroup.Query.GetShopGroup
{
    public class ShopGroupQueryHandler : IRequestHandler<GetShopGroupByGroupIDQuery, List<ShopGroupResult>>
    {
        private readonly ILogger<ShopGroupQueryHandler> _logger;
        private readonly IInventoryRepository _repo;

        public ShopGroupQueryHandler(ILogger<ShopGroupQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<ShopGroupResult>> Handle(GetShopGroupByGroupIDQuery request, CancellationToken cancellationToken)
        {
            var res = await _repo.ShopGroup.GetShopGroupByShopGroupID(request.keyword); 

            return res.ToList();

        }
    }
}

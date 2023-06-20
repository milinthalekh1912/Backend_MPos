using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.ShopGroup.Query.GetShopGroup
{
    public class MerchantGroupQueryHandler : IRequestHandler<GetMerchantGroupByGroupIDQuery, List<MerchantGroupResult>>
    {
        private readonly ILogger<MerchantGroupQueryHandler> _logger;
        private readonly IInventoryRepository _repo;

        public MerchantGroupQueryHandler(ILogger<MerchantGroupQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<MerchantGroupResult>> Handle(GetMerchantGroupByGroupIDQuery request, CancellationToken cancellationToken)
        {
            var res = await _repo.MerchantGroup.GetShopGroupByShopGroupID(request.keyword); 
            return res.ToList();
        }
    }
}

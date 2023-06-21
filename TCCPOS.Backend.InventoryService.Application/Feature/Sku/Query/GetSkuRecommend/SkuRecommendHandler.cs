using MediatR;
using Microsoft.Extensions.Logging;

using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend
{
    public class GetSkuRecommendQueryHandler : IRequestHandler<GetSkuRecommendQuery, List<SkuRecommendResult>>
    {
        private readonly ILogger<GetSkuRecommendQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetSkuRecommendQueryHandler(ILogger<GetSkuRecommendQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }



        public async Task<List<SkuRecommendResult>> Handle(GetSkuRecommendQuery request, CancellationToken cancellationToken)
        {
            var res = await _repo.Sku.GetSkuRecommend(request.Supplier_id,request.Merchant_id);
           
            return res;
        }



    }


}

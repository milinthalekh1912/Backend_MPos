using MediatR;
using Microsoft.Extensions.Logging;

using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductRecommend.Query.GetProductRecommend
{
    public class GetProductRecommendQueryHandler : IRequestHandler<GetProductRecommendQuery, List<ProductRecommendResult>>
    {
        private readonly ILogger<GetProductRecommendQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetProductRecommendQueryHandler(ILogger<GetProductRecommendQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }



            public async Task<List<ProductRecommendResult>> Handle(GetProductRecommendQuery request, CancellationToken cancellationToken)
        {

            var product = await _repo.Sku.GetSkuRecommend(request.supplier_id);
       
            return product.ToList();    
        }



    }

   
}

using MediatR;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;


namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword
{
    public class GetSkuByKeywordQueryHandler : IRequestHandler<GetSkuByKeywordQuery, List<SkuByKeywordResult>>
    {
        private readonly ILogger<GetSkuByKeywordQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetSkuByKeywordQueryHandler(ILogger<GetSkuByKeywordQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }



        public async Task<List<SkuByKeywordResult>> Handle(GetSkuByKeywordQuery request, CancellationToken cancellationToken)
        {

            var product = await _repo.Sku.GetSkuByKeyword(request.keyword);
        

            return product.ToList();
        }
    }
}

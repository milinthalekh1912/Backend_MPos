using MediatR;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;


namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword
{
    public class GetProductByKeywordQueryHandler : IRequestHandler<GetProductByKeywordQuery, List<ProductByKeywordResult>>
    {
        private readonly ILogger<GetProductByKeywordQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetProductByKeywordQueryHandler(ILogger<GetProductByKeywordQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }



        public async Task<List<ProductByKeywordResult>> Handle(GetProductByKeywordQuery request, CancellationToken cancellationToken)
        {

            var product = await _repo.GetProductByKeyword(request.keyword);
        

            return product.ToList();
        }
    }
}

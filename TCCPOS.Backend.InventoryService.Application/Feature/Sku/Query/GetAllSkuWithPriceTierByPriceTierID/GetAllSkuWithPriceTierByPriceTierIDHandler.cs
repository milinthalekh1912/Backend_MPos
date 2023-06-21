using MediatR;
using Microsoft.Extensions.Logging;

using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuWithPriceTierByPriceTierID;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuBySupplierId
{
    public class GetAllSkuWithPriceTierByPriceTierIDQueryHandler : IRequestHandler<GetAllSkuWithPriceTierByPriceTierIDQuery, GetAllSkuWithPriceTierByPriceTierIDResult>
    {
        private readonly ILogger<GetAllSkuWithPriceTierByPriceTierIDQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetAllSkuWithPriceTierByPriceTierIDQueryHandler(ILogger<GetAllSkuWithPriceTierByPriceTierIDQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetAllSkuWithPriceTierByPriceTierIDResult> Handle(GetAllSkuWithPriceTierByPriceTierIDQuery request, CancellationToken cancellationToken)
        {
            //var res = new GetAllSkuWithPriceTierByPriceTierIDResult();
            var obj = await _repo.Sku.GetAllSkuWithPriceTierByPriceTierId(request.SupplierID,request.PriceTierID);
            return obj;
        }



    }


}

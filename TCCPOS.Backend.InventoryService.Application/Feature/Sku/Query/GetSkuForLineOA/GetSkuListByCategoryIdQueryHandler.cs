using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;

namespace TCCPOS.Backend.InventoryService.Application.Feature.SKU.Query.GetSkuListByCategoriesID 
{ 
    public class GetSkuListByCategoryIdQueryHandler : IRequestHandler<GetSkuListByCategoryIdQuery, GetSkuListResult>
    {
        private readonly ILogger<GetSkuListByCategoryIdQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetSkuListByCategoryIdQueryHandler(ILogger<GetSkuListByCategoryIdQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetSkuListResult> Handle(GetSkuListByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var res = new GetSkuListResult();
            var merchant = await _repo.Merchant.getMerchantById(request.MerchantID);
            var skuList = await _repo.Sku.GetSkuBycateID(request.CategoryID,request.SupplierID,merchant.merchant_id);
            var sku_priceList = await _repo.PriceTier.GetAllPriceTierByPriceTierGroupID(merchant.price_tier_id);
            
            foreach ( var sku in skuList ) 
            {
                var sku_price = sku_priceList.FirstOrDefault(x => x.sku_id == sku.sku);
                
                SkuItemResult item = new SkuItemResult();
                item.SkuID = sku.sku;
                item.Price = sku_price != null ? (double)sku_price.price!:0.00 ;
                item.Title = sku.title ?? "";
                item.AliasTitle = sku.aliasTitle ?? sku.title!;
                item.ImageUrl = sku.imageUrl ?? "" ;

                res.items.Add(item);
            }
            return res;
        }
    }
}

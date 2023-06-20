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
            var merchant = await _repo.Merchant.getMerchantById("00001");
            var sku = await _repo.Sku.GetSkuBycateID(request.CategoryID,request.SupplierID,merchant.shop_id);
            
            /*
            var sku_priceList = await _repo.SkuBranchPrice.GetSkuListByGroupPriceId(merchant.CustomerType);

            var skuList = await _repo.Sku.GetSkuListByCategorId(request.CategoryID);

            foreach ( var sku in skuList ) 
            {
                var sku_price = sku_priceList.FirstOrDefault(x => x.SKUID == sku.SKUID);
                
                SkuItemResult item = new SkuItemResult();
                item.SkuID = sku.SKUID;
                item.Price = sku_price != null ? (double)sku_price.Price!:0.00 ;
                item.Title = sku.Title ?? "";
                item.AliasTitle = sku.AliasTitle ?? "";
                item.ImageUrl = sku.ImageUrl ?? "" ;

                res.items.Add(item);
            }*/
            return res;
        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;

using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuBySupplierId
{
    public class GetAllSkuBySupplierIdQueryHandler : IRequestHandler<GetAllSkuBySupplierIdQuery, GetAllSkuResult>
    {
        private readonly ILogger<GetAllSkuBySupplierIdQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetAllSkuBySupplierIdQueryHandler(ILogger<GetAllSkuBySupplierIdQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetAllSkuResult> Handle(GetAllSkuBySupplierIdQuery request, CancellationToken cancellationToken)
        {
            var res = new GetAllSkuResult();
            var req = await _repo.Sku.GetAllSkuBySupplierId(request.SupplierID);
            var merchant_detail = await _repo.Merchant.getMerchantById(request.MerchantID);
            var price_tier = await _repo.PriceTier.GetAllPriceTierByPriceTierGroupID(merchant_detail.price_tier_id);
            foreach(var item in req)
            {
                var sku_price = price_tier.FirstOrDefault(x => x.sku_id == item.sku_id) != null ? price_tier.FirstOrDefault(x => x.sku_id == item.sku_id).price : 0.00;
                GetAllSkuItemResult skuItemResult= new GetAllSkuItemResult();
                skuItemResult.sku = item.sku_id;
                skuItemResult.barcode = item.barcode;
                skuItemResult.title = item.title;
                skuItemResult.aliasTitle = item.alias_title;
                skuItemResult.categoryId = item.category_id;
                skuItemResult.imageUrl = item.image_url;
                skuItemResult.price = sku_price;
                res.item.Add(skuItemResult);
            }
            return res;
        }



    }


}

using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Entities;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuWithPriceTierByPriceTierID;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ISkuRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<sku>> getAllSkuAsync(string supplierId);
        public Task<List<SkuRecommendResult>> GetSkuRecommend(string supplier_id,string merchantId);
        public Task<List<SkuByKeywordResult>> GetSkuByKeyword(string? keyword);
        public Task<List<GetProductByCatResult>> GetSkuBycateID(String categoryId, String supplierId, string shopId);
        public Task<List<sku>> GetAllSkuBySupplierId(string supplier_id);
        public Task<GetAllSkuWithPriceTierByPriceTierIDResult> GetAllSkuWithPriceTierByPriceTierId(string supplier_id, string price_tier_id);

    }
}

using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Entities;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ISkuRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<sku>> getAllSkuAsync();
        public Task<List<SkuRecommendResult>> GetSkuRecommend(string supplier_id);
        public Task<List<SkuByKeywordResult>> GetSkuByKeyword(string? keyword);
        public Task<List<GetProductByCatResult>> GetSkuBycateID(String categoryId, String supplierId, string shopId);
       
    }
}

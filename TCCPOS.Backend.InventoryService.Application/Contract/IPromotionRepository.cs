using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IPromotionRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<PromotionResult>> GetPromotion();
        public Task<List<promotion>> GetPromotionLineOA();
    }
}

using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IPromotionRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<PromotionResult>> GetPromotion();

    }
}

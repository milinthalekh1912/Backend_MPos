using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IPriceTierRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<pricetier>> GetAllPriceTierByPriceTierGroupID(string priceTierGroupID);
    }
}

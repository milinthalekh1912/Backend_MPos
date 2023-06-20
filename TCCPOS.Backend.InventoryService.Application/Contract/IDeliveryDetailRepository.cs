using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IDeliveryDetailRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<deliverydetail>> getDeliveryDetailsByOrderIdAsync(string order_id);


    }
}

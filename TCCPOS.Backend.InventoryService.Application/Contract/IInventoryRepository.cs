using MediatR;
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IInventoryRepository
    {
        Task SaveChangeAsyncWithCommit();
        Task<List<AllAddressResult>> GetAllAddress(string shopId);
        Task<ConfirmLogisticResult> ConfirmLogistic(string shop_id,string user_id, string order_id, string delivery_detail_id);
    }
}

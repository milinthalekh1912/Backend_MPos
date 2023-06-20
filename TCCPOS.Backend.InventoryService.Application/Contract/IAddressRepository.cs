using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IAddressRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<GetAddressByIdResult> GetAddressById(string? address_id);
        public Task<List<AllAddressResult>> GetAllAddress(string shopId);
    }
}

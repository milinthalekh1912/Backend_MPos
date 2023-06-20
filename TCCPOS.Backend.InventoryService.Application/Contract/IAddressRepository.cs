using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IAddressRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<GetAddressByIdResult> GetAddressById(string? address_id);
        public Task<List<AllAddressResult>> GetAllAddress(string shopId);
    }
}

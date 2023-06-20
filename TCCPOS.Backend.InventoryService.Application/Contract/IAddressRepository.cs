using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IAddressRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<shopaddress> GetAddressById(string address_id);
        public Task<List<shopaddress>> GetAllAddress(string shopId);
    }
}

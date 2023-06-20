using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Entities;
namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IMerchantRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<shop> getShopProfileAsync(string shopId);
        public Task<List<GetAllShopResult>> getAllShopAsync();
        public Task<GetAllMerchantAddressResult> getAllShopWithAddressAsync();
        public Task<shop> getMerchantById(string merchantID);
    }
}

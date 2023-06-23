using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Entities;
namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IMerchantRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<merchant> getShopProfileAsync(string shopId);
        public Task<List<GetAllShopResult>> getAllShopAsync();
        public Task<GetAllMerchantAddressResult> getAllShopWithAddressAsync();
        public Task<merchant> getMerchantById(string merchantID);
        Task<List<merchant>> getllMerchant();
    }
}

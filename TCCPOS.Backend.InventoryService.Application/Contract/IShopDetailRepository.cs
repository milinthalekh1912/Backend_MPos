
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Application.Feature.Shop.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Entities;
namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IShopRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<shop> getShopProfileAsync(string shopId);
        public Task<List<GetAllShopResult>> getAllShopAsync();
        public Task<GetAllShopAddressResult> getAllShopWithAddressAsync();
    }
}

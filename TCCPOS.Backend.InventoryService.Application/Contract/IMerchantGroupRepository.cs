using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IMerchantGroupRepository
    {
        Task<List<MerchantGroupResult>> GetShopGroupByShopGroupID(string shopgroupid);
        public Task<shopgroup> createShopGroupAsync(string shopGroupId, string shopGroupName, string userId);

        public Task<List<shop>> addShopToGroupAsync(List<string> shopId);

        public Task<List<GetAllMerchantGroupResult>> getAllShopGroupAsync();

        public Task<GetMerchantGroupByIdResult> getShopGroupById(string shopGroupId);

        public Task<int> deleteShopGroupById(string shopGroupId, string userId);

        public Task<UpdateGroupResult> updateShopGroupById(string shopGroupId, string userId, string shopGroupName, List<string> shopList);

        public Task<List<GetAllShopResult>> getAllShopAsync();

        public Task updateNameByGroupId(string groupName, string shopGroupId, string userId);


    }
}

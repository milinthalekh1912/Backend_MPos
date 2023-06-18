using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IShopGroupRepository
    {
        Task<List<ShopGroupResult>> GetShopGroupByShopGroupID(string shopgroupid);

    }
}

using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class ShopGroupRepository : IShopGroupRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;

        public ShopGroupRepository(InventoryContext context)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        public async Task SaveChangeAsyncWithCommit()
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                _context.Database.SetCommandTimeout(120);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShopGroupResult>> GetShopGroupByShopGroupID(string keyword)
        {
            var shopGroups = await _context.rewardtarget
                .Join(
                    _context.sku,
                    rt => rt.sku_id,
                    sku => sku.sku_id,
                    (rt, sku) => new { RewardTarget = rt, SKU = sku }
                )
                .Join(
                    _context.supplier,
                    joined => joined.SKU.supplier_id,
                    supplier => supplier.supplier_id,
                    (joined, supplier) => new { joined.RewardTarget, joined.SKU, Supplier = supplier }
                )
                .Where(rt => rt.RewardTarget.shop_group_id == keyword)
                .Select(rt => new ShopGroupResult
                {
                    TargetID = rt.RewardTarget.reward_id,
                    SkuID = rt.RewardTarget.sku_id,
                    SkuName = rt.SKU.title,
                    Target = rt.RewardTarget.target,
                    RewardID = rt.RewardTarget.reward,
                    Reward = rt.RewardTarget.reward,
                    ResetDate = rt.RewardTarget.end_date
                })
                .ToListAsync();

            if (shopGroups == null || !shopGroups.Any())    
                throw InventoryServiceException.IE001;

            return shopGroups;
        }
    }
}

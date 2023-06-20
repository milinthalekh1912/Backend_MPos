using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;
using TCCPOS.Backend.InventoryService.Entities;
using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class MerchantGroupRepository : IMerchantGroupRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;

        public MerchantGroupRepository(InventoryContext context, DateTime dtnow)
        {
            _context = context;
            _dtnow = dtnow;
        }

        public async Task<List<MerchantGroupResult>> GetShopGroupByShopGroupID(string keyword)
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
                .Select(rt => new MerchantGroupResult
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

        public async Task<shopgroup> createShopGroupAsync(string shopGroupId, string shopGroupName, string userId)
        {
            var request = new shopgroup
            {
                shop_group_id = shopGroupId,
                group_name = shopGroupName,
                created_by = userId,
                created_date = _dtnow,
                updated_by = userId,
                updated_date = _dtnow
            };

            await _context.shopgroup.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<List<shop>> addShopToGroupAsync(List<string> shopId)
        {
            var newId = Guid.NewGuid().ToString();

            var results = await _context.shop.Where(e => shopId.Contains(e.shop_id)).ToListAsync();

            results.ForEach(shop =>
            {
                if (shop.shop_group_id != null)
                {
                    throw InventoryServiceException.IE012;
                }
                shop.shop_group_id = newId;
            });

            await _context.SaveChangesAsync();

            return results;
        }

        public async Task<List<GetAllMerchantGroupResult>> getAllShopGroupAsync()
        {
            var queryable = from sg in _context.shopgroup
                            join s in _context.shop on sg.shop_group_id equals s.shop_group_id
                            group s by new { sg.shop_group_id, sg.group_name } into g
                            select new
                            {
                                shopGroupId = g.Key.shop_group_id,
                                shopGroupName = g.Key.group_name,
                                totalShop = g.Count()
                            };

            var resultList = await queryable.AsNoTracking().ToListAsync();

            return resultList.Select(e =>
            {
                return new GetAllMerchantGroupResult
                {
                    shopAmount = e.totalShop,
                    shopGroupId = e.shopGroupId,
                    shopGroupName = e.shopGroupName,
                };
            }).ToList();
        }

        public async Task<GetMerchantGroupByIdResult> getShopGroupById(string shopGroupId)
        {
            var shopGroup = await _context.shopgroup.AsNoTracking().FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            var shops = await _context.shop.AsNoTracking().Where(e => e.shop_group_id == shopGroupId).ToListAsync();

            if (shopGroup == null)
            {
                throw InventoryServiceException.IE013;
            }

            return new GetMerchantGroupByIdResult
            {
                shop_group_id = shopGroup.shop_group_id,
                group_name = shopGroup.group_name,
                shopList = shops.Select(e =>
                {
                    return new ShopResult
                    {
                        shopId = e.shop_id,
                        shopName = e.shop_name
                    };
                }).ToList()
            };
        }

        public async Task<int> deleteShopGroupById(string shopGroupId, string userId)
        {
            var users = await _context.shop.Where(e => e.shop_group_id == shopGroupId).ToListAsync();

            users.ForEach(e =>
            {
                e.shop_group_id = null;
                e.updated_date = _dtnow;
                e.updated_by = userId;
            });

            var shopGroup = _context.Remove(_context.shopgroup.Single(e => e.shop_group_id == shopGroupId));
            _context.rewardtarget.RemoveRange(_context.rewardtarget.Where(e => e.shop_group_id == shopGroupId));

            return await _context.SaveChangesAsync();
        }

        public async Task<UpdateGroupResult> updateShopGroupById(string shopGroupId, string userId, string shopGroupName, List<string> shopList)
        {
            var shopGroup = await _context.shopgroup.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            if (shopGroup == null)
            {
                throw InventoryServiceException.IE013;
            }
            shopGroup.group_name = shopGroupName;
            shopGroup.updated_date = _dtnow;
            shopGroup.updated_by = userId;

            var users = await _context.shop.Where(e => e.shop_group_id == shopGroupId).ToListAsync();
            users.ForEach(e =>
            {
                e.shop_group_id = null;
            });

            var results = await _context.shop.Where(e => shopList.Contains(e.shop_id)).ToListAsync();

            results.ForEach(shop =>
            {
                if (shop.shop_group_id != null)
                {
                    throw InventoryServiceException.IE012;
                }
                shop.shop_group_id = shopGroupId;
            });

            await _context.SaveChangesAsync();

            return new UpdateGroupResult
            {
                shopgroup = shopGroup,
                shops = results,
            };
        }

        public async Task<List<GetAllShopResult>> getAllShopAsync()
        {
            var queryable = from s in _context.shop
                            join sg in _context.shopgroup on s.shop_group_id equals sg.shop_group_id into shopGroupJoin
                            from sg in shopGroupJoin.DefaultIfEmpty()
                            select new
                            {
                                s.shop_id,
                                s.shop_name,
                                s.shop_group_id,
                                GroupName = sg != null ? sg.group_name : null
                            };

            var results = await queryable.ToListAsync();

            return results.Select(e =>
            {
                return new GetAllShopResult
                {
                    shopId = e.shop_id,
                    shopGroupId = e.shop_group_id,
                    shopName = e.shop_name,
                    shopGroupName = e.GroupName
                };
            }).ToList();
        }

        public async Task updateNameByGroupId(string groupName, string shopGroupId, string userId)
        {
            var shopGroup = await _context.shopgroup.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            shopGroup.group_name = groupName;
            shopGroup.updated_by = userId;
            shopGroup.updated_date = _dtnow;

            await _context.SaveChangesAsync();
        }

    }
}

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
        public async Task<merchantgroup> CreateShopGroupAsync(string shopGroupId, string shopGroupName, string userId)
        {
            var request = new merchantgroup
            {
                merchant_group_id = shopGroupId,
                group_name = shopGroupName,
                created_by = userId,
                created_date = _dtnow,
                updated_by = userId,
                updated_date = _dtnow
            };

            await _context.merchantgroup.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<List<merchant>> AddShopToGroup(List<string> shopId)
        {
            var newId = Guid.NewGuid().ToString();

            var results = await _context.merchant.Where(e => shopId.Contains(e.merchant_id)).ToListAsync();

            results.ForEach(shop =>
            {
                if (shop.merchant_group_id != null)
                {
                    throw InventoryServiceException.IE012;
                }
                shop.merchant_group_id = newId;
            });

            await _context.SaveChangesAsync();

            return results;
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


        public async Task<List<GetAllMerchantGroupResult>> getAllShopGroupAsync()
        {
            var queryable = from sg in _context.merchantgroup
                            join s in _context.merchant on sg.merchant_group_id equals s.merchant_group_id
                            group s by new { sg.merchant_group_id, sg.group_name } into g
                            select new
                            {
                                shopGroupId = g.Key.merchant_group_id,
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
            var shopGroup = await _context.merchantgroup.AsNoTracking().FirstOrDefaultAsync(e => e.merchant_group_id == shopGroupId);
            var shops = await _context.merchant.AsNoTracking().Where(e => e.merchant_group_id == shopGroupId).ToListAsync();

            if (shopGroup == null)
            {
                throw InventoryServiceException.IE013;
            }

            return new GetMerchantGroupByIdResult
            {
                shop_group_id = shopGroup.merchant_group_id,
                group_name = shopGroup.group_name,
                shopList = shops.Select(e =>
                {
                    return new ShopResult
                    {
                        shopId = e.merchant_id,
                        shopName = e.merchant_name
                    };
                }).ToList()
            };
        }

        public async Task<int> deleteShopGroupById(string shopGroupId, string userId)
        {
            var users = await _context.merchant.Where(e => e.merchant_group_id == shopGroupId).ToListAsync();

            users.ForEach(e =>
            {
                e.merchant_group_id = null;
                e.updated_date = _dtnow;
                e.updated_by = userId;
            });

            var shopGroup = _context.Remove(_context.merchantgroup.Single(e => e.merchant_group_id == shopGroupId));
            _context.rewardtarget.RemoveRange(_context.rewardtarget.Where(e => e.shop_group_id == shopGroupId));

            return await _context.SaveChangesAsync();
        }

        public async Task<UpdateMerchantGroupResult> updateShopGroupById(string shopGroupId, string userId, string shopGroupName, List<string> shopList)
        {
            var shopGroup = await _context.merchantgroup.FirstOrDefaultAsync(e => e.merchant_group_id == shopGroupId);
            if (shopGroup == null)
            {
                throw InventoryServiceException.IE013;
            }
            shopGroup.group_name = shopGroupName;
            shopGroup.updated_date = _dtnow;
            shopGroup.updated_by = userId;

            var users = await _context.merchant.Where(e => e.merchant_group_id == shopGroupId).ToListAsync();
            users.ForEach(e =>
            {
                e.merchant_group_id = null;
            });

            var results = await _context.merchant.Where(e => shopList.Contains(e.merchant_id)).ToListAsync();

            results.ForEach(shop =>
            {
                if (shop.merchant_group_id != null)
                {
                    throw InventoryServiceException.IE012;
                }
                shop.merchant_group_id = shopGroupId;
            });

            await _context.SaveChangesAsync();

            return new UpdateMerchantGroupResult
            {
                shopgroup = shopGroup,
                shops = results,
            };
        }

        public async Task<List<GetAllShopResult>> getAllShopAsync()
        {
            var queryable = from s in _context.merchant
                            join sg in _context.merchantgroup on s.merchant_group_id equals sg.merchant_group_id into shopGroupJoin
                            from sg in shopGroupJoin.DefaultIfEmpty()
                            select new
                            {
                                s.merchant_id,
                                s.merchant_name,
                                s.merchant_group_id,
                                GroupName = sg != null ? sg.group_name : null
                            };

            var results = await queryable.ToListAsync();

            return results.Select(e =>
            {
                return new GetAllShopResult
                {
                    shopId = e.merchant_id,
                    shopGroupId = e.merchant_group_id,
                    shopName = e.merchant_name,
                    shopGroupName = e.GroupName
                };
            }).ToList();
        }

        public async Task updateNameByGroupId(string groupName, string shopGroupId, string userId)
        {
            var shopGroup = await _context.merchantgroup.FirstOrDefaultAsync(e => e.merchant_group_id == shopGroupId);
            shopGroup.group_name = groupName;
            shopGroup.updated_by = userId;
            shopGroup.updated_date = _dtnow;

            await _context.SaveChangesAsync();
        }

    }
}

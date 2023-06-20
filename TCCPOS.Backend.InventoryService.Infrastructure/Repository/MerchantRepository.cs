using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Entities;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public MerchantRepository(InventoryContext context, DateTime _dtnow)
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

        public async Task<shop> getShopProfileAsync(string shopId)
        {
            var shop = await _context.shop.AsNoTracking().FirstOrDefaultAsync(e => e.shop_id == shopId);
            return shop;
        }
        public async Task<GetAllMerchantAddressResult> getAllShopWithAddressAsync()
        {
            {
                var queryable = from s in _context.shop
                                join sg in _context.shopaddress on s.shop_id equals sg.shop_id into shopAddressJoin
                                from sg in shopAddressJoin.DefaultIfEmpty()
                                select new
                                {
                                    s.shop_id,
                                    s.shop_name,
                                    sg.address_id,
                                };

                var results = await queryable.ToListAsync();

                return new GetAllMerchantAddressResult
                {
                    shopAddress = results.Select(e =>
                    {
                        return new ShopWithAddressResult
                        {
                            shop_id = e.shop_id,
                            shop_name = e.shop_name,
                            shop_address_id = e.address_id

                        };
                    }).ToList()
                };
            }
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

    }
}





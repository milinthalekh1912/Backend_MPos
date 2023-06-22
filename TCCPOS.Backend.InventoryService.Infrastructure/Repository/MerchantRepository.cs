using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
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

        public async Task<merchant> getShopProfileAsync(string shopId)
        {
            var shop = await _context.merchant.AsNoTracking().FirstOrDefaultAsync(e => e.merchant_id == shopId);
            return shop;
        }
        public async Task<GetAllMerchantAddressResult> getAllShopWithAddressAsync()
        {
            {
                var queryable = from s in _context.merchant
                                join sg in _context.merchantaddress on s.merchant_id equals sg.merchant_id into shopAddressJoin
                                from sg in shopAddressJoin.DefaultIfEmpty()
                                select new
                                {
                                    s.merchant_id,
                                    s.merchant_name,
                                    s.price_tier_id,
                                    sg.address_id,
                                    sg.address_title,
                                    sg.address1,
                                    sg.address2,
                                    sg.address3,
                                    sg.zipcode
                                };

                var results = await queryable.ToListAsync();

                return new GetAllMerchantAddressResult
                {
                    shopAddress = results.Select(e =>
                    {
                        return new ShopWithAddressResult
                        {
                            merchant_id = e.merchant_id,
                            merchant_name = e.merchant_name,
                            merchant_address_id = e.address_id,
                            price_tier_id = e.price_tier_id,
                            merchant_address_title = e.address_title,
                            merchant_address_1 = e.address1,
                            merchant_address_2 = e.address2,
                            merchant_address_3 = e.address3,
                            merchant_address_zipcode = e.zipcode,
                        };
                    }).ToList()
                };
            }
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


        public async Task<merchant> getMerchantById(string merchantID)
        {
            var merchant_obj = await _context.merchant.FirstOrDefaultAsync(x => x.merchant_id == merchantID);
            if (merchant_obj == null) throw InventoryServiceException.IE020;
            
            return merchant_obj;
        }
    }
}





using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public AddressRepository(InventoryContext context, DateTime _dtnow)
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

        public async Task<List<AllAddressResult>> GetAllAddress(string shopId)
        {
            var shopAddress = await _context.shopaddress.AsNoTracking().Where(e => e.shop_id == shopId).ToListAsync();
            List<AllAddressResult> results = new List<AllAddressResult>();
            if (shopAddress == null || !shopAddress.Any())
            {
                throw InventoryServiceException.IE001;
            }
            foreach (var item in shopAddress)
            {
                AllAddressResult obj = new AllAddressResult();
                obj.addressId = item.address_id;
                obj.shopTitle = item.shop_title;
                obj.address1 = item.address1;
                obj.address2 = item.address2;
                obj.address3 = item.address3;
                obj.zipcode = item.zipcode;
                obj.phoneNumber = item.phone_number;
                results.Add(obj);
            }
            return results;
        }

        public async Task<GetAddressByIdResult> GetAddressById(string? address_id)
        {
            var address = await _context.shopaddress.FirstOrDefaultAsync(elem => elem.address_id == address_id);

            var result = new GetAddressByIdResult()
            {
                addressId = address?.address_id,
                address1 = address?.address1,
                address2 = address?.address2,
                address3 = address?.address3,
                zipcode = address?.zipcode
            };

            return result;
        }


    }
}





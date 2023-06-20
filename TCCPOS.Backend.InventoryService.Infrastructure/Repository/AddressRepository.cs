using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Entities;

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

        public async Task<List<shopaddress>> GetAllAddress(string shopId)
        {
            var shopAddress = await _context.shopaddress.AsNoTracking().Where(e => e.shop_id == shopId).ToListAsync();
            return shopAddress;
        }

        public async Task<shopaddress> GetAddressById(string address_id)
        {
            var result = await _context.shopaddress.FirstOrDefaultAsync(elem => elem.address_id == address_id);
            return result;
        }


    }
}





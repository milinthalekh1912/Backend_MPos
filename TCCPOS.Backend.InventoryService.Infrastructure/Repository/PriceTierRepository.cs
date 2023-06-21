using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class PriceTierRepository : IPriceTierRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public PriceTierRepository(InventoryContext context, DateTime _dtnow)
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

        public async Task<List<pricetier>> GetAllPriceTierByPriceTierGroupID(string priceTierGroupID)
        {
            return await _context.pricetier.Where(x => x.price_tier_group_id == priceTierGroupID).ToListAsync();  
        }

        public async Task<List<pricetiergroup>> GetAllPriceTierBySupplierID(string supplierID)
        {
            return await _context.pricetiergroup.Where(x => x.supplier_id == supplierID).ToListAsync();
        }

    }
}





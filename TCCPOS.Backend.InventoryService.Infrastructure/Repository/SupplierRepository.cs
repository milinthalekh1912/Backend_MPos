using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier;
using TCCPOS.Backend.InventoryService.Entities;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public SupplierRepository(InventoryContext context, DateTime _dtnow)
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

        public async Task<List<SupplierResult>> GetSupplier()
        {
            var suppliers = await _context.supplier.Where(x => true).ToListAsync(); // Retrieve all suppliers

            List<SupplierResult> result = new List<SupplierResult>();

            foreach (var supplier in suppliers)
            {
                SupplierResult obj = new SupplierResult();
                obj.shopId = supplier.supplier_id;
                obj.shopTitle = supplier.supplier_name;
                obj.shopImageUrl = supplier.supplier_image;
                obj.isPriceShow = supplier.is_show_price ?? false;
                obj.isStockShow = supplier.is_show_stock ?? false;

                result.Add(obj);
            }


            return result;
        }

    }
}





using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;

        public InventoryRepository(InventoryContext context)
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

        
    }
}

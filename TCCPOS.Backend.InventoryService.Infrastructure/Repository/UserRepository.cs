using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public UserRepository(InventoryContext context, DateTime _dtnow)
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



        public async Task<user?> GetUserByUserID(string userID)
        {
            var user = await _context.user.FirstOrDefaultAsync(x => x.id == userID);
            return user;
        }




    }
}





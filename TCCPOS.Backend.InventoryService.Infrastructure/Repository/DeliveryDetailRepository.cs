using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Entities;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class DeliveryDetailRepository : IDeliveryDetailRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public DeliveryDetailRepository(InventoryContext context, DateTime _dtnow)
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
      
        public async Task<deliverydetail> createDeliveryDetailAsync(string order_id, string userId)
        {
            List<deliverydetail> deliveryDetails = new List<deliverydetail>();

            deliveryDetails.Add(new deliverydetail
            {
                delivery_detail_id = Guid.NewGuid().ToString(),
                order_id = order_id,
                cost = 0,
                estimate_date = _dtnow,
                due_date = _dtnow,
                is_express = false,
            });


            deliveryDetails.Add(new deliverydetail
            {
                delivery_detail_id = Guid.NewGuid().ToString(),
                order_id = order_id,
                cost = 0,
                estimate_date = _dtnow,
                due_date = _dtnow,
                is_express = true,
            });

            await _context.AddRangeAsync(deliveryDetails);
            await _context.SaveChangesAsync();
            return new deliverydetail();
        }

        public async Task<List<deliverydetail>> getDeliveryDetailsByOrderIdAsync(string order_id)
        {
            var deliverysDetail = await _context.deliverydetail.AsNoTracking().Where(e => e.order_id == order_id).ToListAsync();
            return deliverysDetail;
        }


    }
}





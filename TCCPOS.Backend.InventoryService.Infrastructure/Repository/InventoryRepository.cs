using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;
using TCCPOS.Backend.InventoryService.Entities;

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

        public async Task<List<AllAddressResult>> GetAllAddress(string shopId)
        {
            var shopAddress = await _context.shopaddress.AsNoTracking().Where(e => e.shop_id == shopId).ToListAsync();
            List < AllAddressResult > results = new List<AllAddressResult>();
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

        public async Task<ConfirmLogisticResult> ConfirmLogistic(string shop_id, string user_id, string order_id, string delivery_detail_id)
        {
            var order = await _context.order.Where(e => e.order_id == order_id).FirstOrDefaultAsync();
            if (order == null)
            {
                throw InventoryServiceException.IE001;
            }
            order.delivery_detail_id = delivery_detail_id;
            order.updated_date = _dtnow;
            order.updated_by = user_id;
            order.order_status = '2';

            var updatedelivery = new ConfirmLogisticResult
            {
                delivery_detail_id = delivery_detail_id,
                user_id = user_id,
                shop_id = shop_id,
                order_id = order_id,
            };

            await _context.SaveChangesAsync();

            return updatedelivery;
        }
    }
}

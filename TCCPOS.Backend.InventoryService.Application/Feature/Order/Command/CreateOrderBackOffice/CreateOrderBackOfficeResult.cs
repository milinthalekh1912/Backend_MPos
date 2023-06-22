using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice
{
    public class CreateOrderBackOfficeResult
    {
        public string userId { get; set; }
        public string orderId { get; set; }
        public string merchantId { get; set; }
        public string supplierId { get; set; }
        public string deliverlyId { get; set; }
        public string? couponId { get; set; } = null!;
        public string addressId { get; set; }
        public List<CreateOrderBackofficeItemRequest> orderItem { get; set; } = new List<CreateOrderBackofficeItemRequest>();
    }
}

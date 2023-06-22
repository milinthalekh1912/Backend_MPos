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
        public string user_id { get; set; }
        public string shop_id { get; set; }
        public string supplier_id { get; set; }
        public string? coupon_id { get; set; } = null!;
        public string address_id { get; set; }
        public List<CreateOrderBackofficeItemRequest> order_items { get; set; } = new List<CreateOrderBackofficeItemRequest>();
    }
}

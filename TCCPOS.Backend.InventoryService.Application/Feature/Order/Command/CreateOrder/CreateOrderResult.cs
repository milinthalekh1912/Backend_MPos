using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder
{
    public class CreateOrderResult
    {
        public string user_id { get; set; }
        public string shop_id { get; set; }
        public string supplier_id { get; set; }
        public string? coupon_id { get; set; } = null!;
        public string address_id { get; set; }
        public List<OrderItemRequest> order_items { get; set; }
    }
}

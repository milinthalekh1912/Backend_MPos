using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders
{
    public class GetAllOrdersResult
    {
        public string order_id {get; set; }
        public bool is_read {get; set; }
        public string user_id { get; set; }
        public string shop_id { get; set; } 
        public string shop_name { get; set; }
        public int order_amount { get; set; }
        public string address_id { get; set; }
        public List<OrderItemResult> order_items { get; set; }
    }



}


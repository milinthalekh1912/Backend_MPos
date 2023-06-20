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
        public string order_id { get; set; }
        public string order_no { get; set; }
        public double total { get; set; }
        public double total_discount { get; set; }
        public bool is_read { get; set; }
        public int order_status { get; set; }
        public string user_id { get; set; }
        public string shop_id { get; set; }
        public string supplier_name { get; set; }
        public string customer_name { get; set; }
        public int order_amount { get; set; }
        public string address_id { get; set; }
        public DateTime created_date { get; set; }
        public List<OrderItemResult> order_items { get; set; }
    }

}


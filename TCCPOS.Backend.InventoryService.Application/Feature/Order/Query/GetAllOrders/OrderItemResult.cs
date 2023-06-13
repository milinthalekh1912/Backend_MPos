using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders
{
    public class OrderItemResult
    {
        public string order_item_id { get; set; }
        public string sku_id { get; set; }
        public int amount { get; set; }
        public double? price { get; set; }
        public string sku_title { get; set; }
        public string sku_alias_title { get; set; }
        public string sku_barcode { get; set; }
        public string image_url { get; set; }
        public string sku_category_id { get; set; }
    }
}

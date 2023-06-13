using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic
{
    public class ConfirmLogisticResult
    {
        public string user_id { get; set; }
        public string shop_id { get; set; }
        public string order_id { get; set; }
        public string delivery_detail_id { get; set; }
        public string address_id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop
{
    public class GetAllShopResult
    {
        public string shopId { get; set; }
        public string shopName { get; set; }
        public string shopGroupId { get; set; }
        public string shopGroupName { get; set; }
    }
}

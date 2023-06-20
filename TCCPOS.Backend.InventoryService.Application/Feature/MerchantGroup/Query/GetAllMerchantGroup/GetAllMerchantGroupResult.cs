using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup
{
    public class GetAllMerchantGroupResult
    {
        public string shopGroupId { get; set; }

        public string shopGroupName { get; set; }

        public int shopAmount { get; set; }
    }
}

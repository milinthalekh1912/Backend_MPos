using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById
{
    public class GetShopGroupByIdResult
    {
        public string shop_group_id { get; set; }

        public string group_name { get; set; }

        public List<ShopResult> shopList { get; set; }
    }


    public class ShopResult
    {
        public string shopId { get; set; }
        public string shopName { get; set; }
    }
}

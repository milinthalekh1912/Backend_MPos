using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop
{
    public class GetAllMerchantAddressResult
    {
        public List<ShopWithAddressResult> shopAddress { get; set; } = null;
    }

    public class ShopWithAddressResult
    {
        public string shop_id { get; set; }

        public string shop_name { get; set; }

        public string shop_address_id { get; set; }

    }
}

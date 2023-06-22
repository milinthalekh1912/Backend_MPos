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
        public string merchant_id { get; set; }
        public string price_tier_id { get; set; }
        public string merchant_name { get; set; }
        public string merchant_address_id { get; set; }
        public string merchant_address_title { get; set; }
        public string merchant_address_1 { get; set; }
        public string merchant_address_2 { get; set; }
        public string merchant_address_3 { get; set; }
        public string merchant_address_zipcode { get; set; }

    }
}

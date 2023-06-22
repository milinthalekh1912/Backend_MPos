using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterMerchantBackOffice
{
    public class RegisterMerchantBackOfficeResult
    {
        public string merchantId { get; set; } = null!;
        public string merchantName { get; set; } = null!;
        public string priceTierId { get; set; } = null!;
        public string merchantGroupId { get; set; } = null!;
        public string merchantAddressId { get; set; } = null!;
        public string addressTitle { get; set; } = null!;
        public string address1 { get; set; } = null!;
        public string address2 { get; set; } = null!;
        public string address3 { get; set; } = null!;
        public string zipcode { get; set; } = null!;
        public string phoneNumber { get; set; } = null!;
    }
}
/*
 public string merchant_id { get; set; }
        public string price_tier_id { get; set; }
        public string merchant_name { get; set; }
        public string merchant_address_id { get; set; }
        public string merchant_address_title { get; set; }
        public string merchant_address_1 { get; set; }
        public string merchant_address_2 { get; set; }
        public string merchant_address_3 { get; set; }
        public string merchant_address_zipcode { get; set; }
 
 */
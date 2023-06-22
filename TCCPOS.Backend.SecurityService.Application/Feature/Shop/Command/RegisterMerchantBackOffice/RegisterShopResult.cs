using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterMerchantBackOffice
{
    public class RegisterMerchantBackOfficeResult
    {
        public string merchant_id { get; set; } = null!;
        public string merchant_name { get; set; } = null!;
        public string price_tier_id { get; set; } = null!;
        //public string merchantGroupId { get; set; } = null!;
        public string merchant_address_id { get; set; } = null!;
        public string merchant_address_title { get; set; } = null!;
        public string merchant_address_1 { get; set; } = null!;
        public string merchant_address_2 { get; set; } = null!;
        public string merchant_address_3 { get; set; } = null!;
        public string merchant_address_zipcode { get; set; } = null!;
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
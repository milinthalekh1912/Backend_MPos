using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterShop
{
    public class RegisterShopResult
    {
        public string shopId { get; set; } = null!;
        public string shop_name { get; set; } = null!;
        public string priceTierId { get; set; } = null!;
        public string shop_group_id { get; set; } = null!;
  
        public string address1 { get; set; } = null!;

        public string address2 { get; set; } = null!;

        public string address3 { get; set; } = null!;

        public string zipcode { get; set; } = null!;

        public string phone_number { get; set; } = null!;
    }
}

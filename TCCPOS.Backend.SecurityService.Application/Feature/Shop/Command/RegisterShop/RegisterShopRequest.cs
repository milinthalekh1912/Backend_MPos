using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterShop
{
    public class RegisterShopRequest
    {
        public string? priceTierId { get; set; } = null!;
        public string? shop_group_id { get; set; } = null!;
        [Required]
        public string shop_name { get; set; } = null!;
        [Required]
        public string address1 { get; set; } = null!;
        public string? address2 { get; set; } = "";
        public string? address3 { get; set; } = "";
        [Required]
        public string zipcode { get; set; } = null!;
        [Required]
        public string phone_number { get; set; } = null!;
    }
}

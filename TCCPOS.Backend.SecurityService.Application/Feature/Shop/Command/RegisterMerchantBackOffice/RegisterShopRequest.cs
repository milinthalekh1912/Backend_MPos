using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterMerchantBackOffice
{
    public class RegisterShopBackOfficeRequest
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string priceTierId { get; set; }
        
        public string? merchantGroupId { get; set; } = null;

        [Required]
        public string merchantName { get; set; } = null!;
        [Required]
        public string addressTitle { get; set; }
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

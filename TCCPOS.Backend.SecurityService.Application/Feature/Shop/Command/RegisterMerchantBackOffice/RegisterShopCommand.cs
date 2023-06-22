using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterMerchantBackOffice
{
    public class RegisterMerchantBackOfficeCommand : IRequest<RegisterMerchantBackOfficeResult>
    {
        public string UserId { get; set; }
        public string PriceTierId { get; set; }
        public string MerchantGroupId { get; set; }
        public string MerchanrName { get; set; }
        public string AddressTitle { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Zipcode { get; set; } 
        public string PhoneNumber { get; set; }
        public RegisterMerchantBackOfficeCommand(RegisterShopBackOfficeRequest command)
        {
            UserId = command.userId;
            PriceTierId = command.priceTierId;
            MerchantGroupId = command.merchantGroupId;
            MerchanrName= command.merchantName;
            AddressTitle = command.addressTitle;
            Address1 = command.address1;
            Address2 = command.address2 ?? "";
            Address3 = command.address3 ?? "";
            Zipcode = command.zipcode;
            PhoneNumber = command.phone_number;
        }

    }
}

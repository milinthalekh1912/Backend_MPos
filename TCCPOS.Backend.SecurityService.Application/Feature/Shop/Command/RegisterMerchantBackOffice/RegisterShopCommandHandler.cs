using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterMerchantBackOffice
{
    public class RegisterMerchantBackOfficeCommandHandler : IRequestHandler<RegisterMerchantBackOfficeCommand, RegisterMerchantBackOfficeResult>
    {
        private readonly ILogger<RegisterMerchantBackOfficeCommandHandler> _logger;
        ISecurityRepository _repo;
        IConfiguration _config;

        public RegisterMerchantBackOfficeCommandHandler(ILogger<RegisterMerchantBackOfficeCommandHandler> logger, ISecurityRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<RegisterMerchantBackOfficeResult> Handle(RegisterMerchantBackOfficeCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId != "ADMIN") throw SecurityServiceException.SE019;

            var newMerchant = await _repo.createMerchantAsync(request.MerchanrName, request.PriceTierId, request.MerchantGroupId, request.UserId);
            var newAddressMerchant = await _repo.createNewShopAddress(newMerchant.merchant_id, request.MerchanrName, request.Address1, request.Address2, request.Address3, request.Zipcode, request.PhoneNumber, request.UserId);
            
            return new RegisterMerchantBackOfficeResult
            {
                merchant_id = newMerchant.merchant_id,
                merchant_name = newMerchant.merchant_name,
                price_tier_id = newMerchant.price_tier_id,
                //merchantGroupId = newMerchant.merchant_group_id,
                merchant_address_id = newAddressMerchant.address_id,
                merchant_address_title = newAddressMerchant.address_title,
                merchant_address_1 = newAddressMerchant.address1,
                merchant_address_2 = newAddressMerchant.address2,
                merchant_address_3 = newAddressMerchant.address3,
                merchant_address_zipcode = newAddressMerchant.zipcode,
                //phoneNumber = newAddressMerchant.phone_number,
            };
        }

    }
}

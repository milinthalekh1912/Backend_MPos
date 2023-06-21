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

namespace TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterShop
{
    public class RegisterShopCommandHandler : IRequestHandler<RegisterShopCommand, RegisterShopResult>
    {
        private readonly ILogger<RegisterShopCommandHandler> _logger;
        ISecurityRepository _repo;
        IConfiguration _config;

        public RegisterShopCommandHandler(ILogger<RegisterShopCommandHandler> logger, ISecurityRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<RegisterShopResult> Handle(RegisterShopCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.getUserById(request.userId);
            if (user.shop_id != null) throw SecurityServiceException.SE019;
            var newShop = await _repo.createShopAsync(request.shop_name, request.priceTierId, request.shop_group_id, request.userId);
            var newAddressShop = await _repo.createNewShopAddress(newShop.merchant_id, request.shop_name, request.address1, request.address2, request.address3, request.zipcode, request.phone_number, request.userId);
            await _repo.updateUserShopId(request.userId, newShop.merchant_id);

            return new RegisterShopResult
            {
                shopId = newShop.merchant_id,
                shop_name = newShop.merchant_name,
                priceTierId = newShop.price_tier_id,
                shop_group_id = newShop.merchant_group_id,
                address1 = newAddressShop.address1,
                address2 = newAddressShop.address2,
                address3 = newAddressShop.address3,
                zipcode = newAddressShop.zipcode,
                phone_number = newAddressShop.phone_number,
            };
        }

    }
}

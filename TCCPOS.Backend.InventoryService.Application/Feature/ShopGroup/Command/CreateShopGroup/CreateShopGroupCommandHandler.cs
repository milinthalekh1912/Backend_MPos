using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup
{
    internal class CreateShopGroupCommandHandler : IRequestHandler<CreateShopGroupCommand, CreateShopGroupResult>
    {

        private readonly ILogger<CreateShopGroupCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public CreateShopGroupCommandHandler(ILogger<CreateShopGroupCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<CreateShopGroupResult> Handle(CreateShopGroupCommand request, CancellationToken cancellationToken)
        {
            var shops = await _repo.addShopToGroupAsync(request.shopId);
            var newShopGroup = await _repo.createNewGroupAsync(shops.First().shop_group_id, request.shopGroupName, request.userId);

            return new CreateShopGroupResult
            {
                shopgroup = newShopGroup,
                shops = shops
            };
        }


    }
}

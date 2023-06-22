using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using MediatR;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice
{
    public class CreateOrderBackOfficeCommandHandler : IRequestHandler<CreateOrderBackOfficeCommand, CreateOrderBackOfficeResult>
    {
        private readonly ILogger<CreateOrderBackOfficeCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public CreateOrderBackOfficeCommandHandler(ILogger<CreateOrderBackOfficeCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<CreateOrderBackOfficeResult> Handle(CreateOrderBackOfficeCommand request, CancellationToken cancellationToken)
        {
            CreateOrderBackOfficeResult res = new CreateOrderBackOfficeResult();
            //var order_id = Guid.NewGuid().ToString();
            /*var all_sku = await _repo.Sku.getAllSkuAsync(request.supplier_id);

            request.order_items.ForEach(e =>
            {
                var index = all_sku.FindIndex(x => x.sku_id == e.sku_id);
                if (index == -1)
                {
                    throw InventoryServiceException.IE016;
                }
            });*/

            //var newOrder = await _repo.Order.createOrderAsync(order_id, request.user_id, request.merchant_id, request.supplier_id, request.address_id, request.coupon_id);
            //var newOrderItem = await _repo.Order.createOrderItemAsync(order_id, request.order_items, request.user_id, request.merchant_id);
            //var newDeliveryDetail = await _repo.createOrderDeliveryDetailAsync(newOrder.order_id, request.user_id);

            //add price 
            return res;
        }

    }
}

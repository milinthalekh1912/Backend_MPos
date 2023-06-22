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

        public async Task<CreateOrderBackOfficeResult> Handle(CreateOrderBackOfficeCommand command, CancellationToken cancellationToken)
        {
            CreateOrderBackOfficeResult res = new CreateOrderBackOfficeResult();

            var order_id = Guid.NewGuid().ToString();
            var newOrder = await _repo.Order.createOrderBackOffice(order_id,command);
            var newOrderItem = await _repo.Order.createOrderItemBackOffice(order_id, command.Order_Items,command.UserID, command.MerchantID);
            //var newDeliveryDetail = await _repo.createOrderDeliveryDetailAsync(newOrder.order_id, request.user_id);
            res.supplier_id = command.SupplierID;
            res.address_id = command.AddressID;
            res.user_id = command.UserID;
            res.coupon_id = command.CouponID;
            res.order_items = command.Order_Items;
            return res;
        }

    }
}

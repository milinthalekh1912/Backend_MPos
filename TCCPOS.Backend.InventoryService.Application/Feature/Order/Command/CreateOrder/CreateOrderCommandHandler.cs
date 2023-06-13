﻿using MediatR;
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

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = await _repo.createOrderAsync(request.user_id, request.shop_id, request.supplier_id, request.address_id, request.coupon_id);
            var newOrderItem = await _repo.createOrderItemAsync(newOrder.order_id, request.order_items, request.user_id);
            var newDeliveryDetail = await _repo.createOrderDeliveryDetailAsync(newOrder.order_id, request.user_id);
            return new CreateOrderResult
            {
                shop_id = newOrder.shop_id,
                supplier_id = newOrder.supplier_id,
                address_id = newOrder.supplier_id,
                user_id = newOrder.user_id,
                coupon_id = newOrder.coupon_id,
                order_items = newOrderItem.Select(e =>
                {
                    return new OrderItemRequest
                    {
                        sku_id = e.sku_id,
                        amount = e.amount ?? 0,
                    };
                }).ToList(),
            };
        }

    }
}

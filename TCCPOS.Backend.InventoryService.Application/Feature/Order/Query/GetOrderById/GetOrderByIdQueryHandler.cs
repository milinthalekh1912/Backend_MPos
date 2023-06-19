﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        private readonly ILogger<GetOrderByIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetOrderByIdQueryHandler(ILogger<GetOrderByIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {

            GetOrderByIdResult orderDetail;

            if (request.shopId == "ADMIN")
            {
                orderDetail = await _repo.Order.getOrderByIdBackOfficeAsync(request.orderId);
            }
            else
            {
                orderDetail = await _repo.Order.getOrderByIdAsync(request.orderId, request.shopId);
            }

            if (orderDetail == null)
            {
                throw InventoryServiceException.IE013;
            }
            var deliverysDetail = await _repo.DeliveryDetail.getDeliveryDetailsByOrderIdAsync(request.orderId);

            orderDetail.deliverydetails = deliverysDetail;
            return orderDetail;
        }
    }
}

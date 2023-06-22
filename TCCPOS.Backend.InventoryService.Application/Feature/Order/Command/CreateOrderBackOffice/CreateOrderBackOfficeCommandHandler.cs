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
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;

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
            
            ConfirmOrderRequest confirmOrderRequest = new ConfirmOrderRequest();
            confirmOrderRequest.orderId = order_id;
            confirmOrderRequest.esimate_date = command.EsimateDate;
            confirmOrderRequest.due_date = command.DueDate;
            confirmOrderRequest.is_boardcase = command.IsBoardcase;
            confirmOrderRequest.note = command.Note;

            ConfirmOrderCommand confirmOrder = new ConfirmOrderCommand(command.UserID,command.MerchantID,confirmOrderRequest);
            var newDeliveryDetail = await _repo.Order.ConfirmOrderByBackOffice(confirmOrder);

            res.orderId = newOrder.order_id;
            res.merchantId = newOrder.merchant_id;
            res.supplierId = newOrder.supplier_id;
            res.deliverlyId = newDeliveryDetail.delivery_detail_id;
            res.addressId = newOrder.address_id;
            res.userId = newOrder.user_id;
            res.couponId = command.CouponID;
            res.orderItem = command.Order_Items;
            return res;
        }

    }
}

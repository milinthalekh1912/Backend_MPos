﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.UpdateOrderStatus;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger;
        IConfiguration _config;

        public OrdersController(ILogger<OrdersController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }


        [Authorize]
        [HttpPost("CreateOrder")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(CreateOrderResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
        {
            var res = await _mediator.Send(new CreateOrderCommand
            {
                supplier_id = request.supplier_id,
                address_id = request.address_id,
                coupon_id = request.coupon_id,
                user_id = Identity.GetUserID(),
                shop_id = Identity.GetShopID(),
                order_items = request.order_items,
            });
            return Ok(res);
        }


        [Authorize]
        [HttpGet("GetOrderList")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(List<GetAllOrdersResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllOrder(string supplierId)
        {
            var res = await _mediator.Send(new GetAllOrdersQuery
            {
                supplierId = supplierId,
                userId = Identity.GetUserID(),
                shopId = Identity.GetShopID(),
            });

            return Ok(res);
        }



        [Authorize]
        [HttpGet("GetOrderById")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(GetOrderByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            var res = await _mediator.Send(new GetOrderByIdQuery
            {
                orderId = orderId,
                shopId = Identity.GetShopID(),
            });
            return Ok(res);
        }

        [Authorize]
        [HttpPut("ConfirmOrder")]
        [SwaggerOperation(Summary = "Confirm Order Status => 2", Description = "")]
        [ProducesResponseType(typeof(ConfirmOrderResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ConfirmOrder([FromBody] ConfirmOrderRequest request)
        {
            var command = new ConfirmOrderCommand(Identity.GetUserID(), Identity.GetShopID(), request);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [Authorize]
        [HttpPut("UpdateOrderStatus")]
        [SwaggerOperation(Summary = "Update Order Status 2 => ++", Description = "")]
        [ProducesResponseType(typeof(UpdateOrderStatusResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusRequest request)
        {
            var command = new UpdateOrderStatusCommand(Identity.GetUserID(), Identity.GetShopID(), request);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}

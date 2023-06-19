using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.UpdateOrderStatus;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
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
        [HttpPost()]
        [SwaggerOperation(Summary = "Create order", Description = "")]
        [ProducesResponseType(typeof(CreateOrderResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> createOrder([FromBody] CreateOrderRequest request)
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
        [HttpGet("All/{supplierId}")]
        [SwaggerOperation(Summary = "Get all order by supplierId", Description = "")]
        [ProducesResponseType(typeof(List<GetAllOrdersResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllOrders(string supplierId)
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
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get order by id", Description = "")]
        [ProducesResponseType(typeof(GetOrderByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getOrderById(string id)
        {
            var res = await _mediator.Send(new GetOrderByIdQuery
            {
                orderId = id,
                shopId = Identity.GetShopID(),
            });
            return Ok(res);
        }

        [Authorize]
        [HttpPut("OrderStatus")]
        [SwaggerOperation(Summary = "Update order status(backoffice)", Description = "Update Order Status 2 => ++")]
        [ProducesResponseType(typeof(UpdateOrderStatusResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateOrderStatus([FromBody] UpdateOrderStatusRequest request)
        {
            var command = new UpdateOrderStatusCommand(Identity.GetUserID(), Identity.GetShopID(), request);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [Authorize]
        [HttpPut("Confirm/backoffice")]
        [SwaggerOperation(Summary = "Confirm order (backoffice)", Description = "Confirm Order Status => 2")]
        [ProducesResponseType(typeof(ConfirmOrderResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> confirmOrder([FromBody] ConfirmOrderRequest request)
        {
            var command = new ConfirmOrderCommand(Identity.GetUserID(), Identity.GetShopID(), request);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("Confirm/user")]
        [SwaggerOperation(Summary = "Confirm order (user)", Description = "Confirm Order Status => 2")]
        [ProducesResponseType(typeof(ConfirmLogisticResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ConfirmLogisticRequest request)
        {
            var data = new ConfirmLogisticCommand
            {
                shop_id = Identity.GetShopID(),
                user_id = Identity.GetUserID(),
                order_id = request.order_id,
                delivery_detail_id = request.delivery_detail_id,
            };
            var res = await _mediator.Send(data);
            return Ok(res);
        }




    }
}

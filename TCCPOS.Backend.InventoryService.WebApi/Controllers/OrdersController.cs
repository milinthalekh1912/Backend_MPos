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
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.UpdateOrderStatus;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrderByMerchantId;
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

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(Summary = "Get order by id", Description = "")]
        [ProducesResponseType(typeof(GetOrderByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var query = new GetOrderByIdQuery(Identity.GetMerchantID(),id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

    
        [HttpGet]
        [Route("")]
        [SwaggerOperation(Summary = "Get All order by Merchant", Description = "")]
        [ProducesResponseType(typeof(GetAllOrderByMerchantIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetOrderByUser()
        {
            var query = new GetAllOrderByMerchantIdQuery(Identity.GetMerchantID());
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpPost]
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
                shop_id = Identity.GetMerchantID(),
                order_items = request.order_items,
            });
            return Ok(res);
        }

        /*[HttpPost]
        [Route("OrderBackOffice")]
        [SwaggerOperation(Summary = "Create order Backoffice", Description = "")]
        [ProducesResponseType(typeof(CreateOrderResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateOrderBackOffice([FromBody] CreateOrderBackOfficeRequest request)
        {
            var com = new CreateOrderBackOfficeCommand(Identity.GetUserID(),,request);
            var res = await _mediator.Send(new CreateOrderCommand
            {
                supplier_id = request.supplier_id,
                address_id = request.address_id,
                coupon_id = request.coupon_id,
                user_id = Identity.GetUserID(),
                merchant_id = Identity.GetMerchantID(),
                order_items = request.order_items,
            });
            return Ok(res);
        }*/

        [HttpGet]
        [Route("All/{supplierId}")]
        [SwaggerOperation(Summary = "Get all order by supplierId", Description = "")]
        [ProducesResponseType(typeof(List<GetAllOrdersResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllOrders(string supplierId)
        {
            var res = await _mediator.Send(new GetAllOrdersQuery
            {
                supplierId = supplierId,
                userId = Identity.GetUserID(),
                shopId = Identity.GetMerchantID(),
            });

            return Ok(res);
        }

        [HttpPut("OrderStatus")]
        [SwaggerOperation(Summary = "Update order status(backoffice)", Description = "Update Order Status 2 => ++")]
        [ProducesResponseType(typeof(UpdateOrderStatusResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateOrderStatus([FromBody] UpdateOrderStatusRequest request)
        {
            var command = new UpdateOrderStatusCommand(Identity.GetUserID(), Identity.GetMerchantID(), request);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("Confirm/backoffice")]
        [SwaggerOperation(Summary = "Confirm order (backoffice)", Description = "Confirm Order Status => 2")]
        [ProducesResponseType(typeof(ConfirmOrderResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> confirmOrder([FromBody] ConfirmOrderRequest request)
        {
            var command = new ConfirmOrderCommand(Identity.GetUserID(), Identity.GetMerchantID(), request);
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
                shop_id = Identity.GetMerchantID(),
                user_id = Identity.GetUserID(),
                order_id = request.order_id,
                delivery_detail_id = request.delivery_detail_id,
            };
            var res = await _mediator.Send(data);
            return Ok(res);
        }

    }
}

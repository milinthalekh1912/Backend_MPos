using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Principal;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConfirmLogisticController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConfirmLogisticController> _logger;
        public ConfirmLogisticController(ILogger<ConfirmLogisticController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "confirmLogistic")]
        [ProducesResponseType(typeof(ConfirmLogisticResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ConfirmLogisticRequest request)
        {
            var data = new ConfirmLogisticCommand
            {
                shop_id = Identity.GetShopID(),
                user_id = Identity.GetUserID(),
                order_id =  request.order_id,
                delivery_detail_id = request.delivery_detail_id,
            };
            var res = await _mediator.Send(data);
            return Ok(res);
        }
    }
}

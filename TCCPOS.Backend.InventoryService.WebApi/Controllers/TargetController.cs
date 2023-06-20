using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.DeleteTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TargetController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TargetController> _logger;
        IConfiguration _config;

        public TargetController(ILogger<TargetController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [Authorize]
        [HttpPost()]
        [SwaggerOperation(Summary = "Create", Description = "")]
        [ProducesResponseType(typeof(CreateTargetResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> createTarget([FromBody] CreateTargetRequest request)
        {
            var res = await _mediator.Send(new CreateTargetCommand
            {
                shopGroupId = request.shopGroupId,
                skuId = request.skuId,
                target = request.target,
                reward = request.reward,
                resetDate = request.resetDate,
                userId = Identity.GetUserID()
            });
            return Ok(res);
        }

        [Authorize]
        [HttpPut()]
        [SwaggerOperation(Summary = "Update", Description = "")]
        [ProducesResponseType(typeof(UpdateTargetResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateTarget([FromBody] UpdateTargetRequest request)
        {
            var res = await _mediator.Send(new UpdateTargetCommand
            {
                targetId = request.targetId,
                shopGroupId = request.shopGroupId,
                skuId = request.skuId,
                target = request.target,
                reward = request.reward,
                resetDate = request.resetDate,
                userId = Identity.GetUserID()
            });
            return Ok(res);
        }

        [Authorize]
        [HttpDelete]
        [SwaggerOperation(Summary = "Delete", Description = "")]
        [ProducesResponseType(typeof(DeleteTargetRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> deleteTarget([FromBody] DeleteTargetRequest request)
        {
            var res = await _mediator.Send(new DeleteTargetCommand
            {
                shopGroupId = request.shopGroupId,
                skuId = request.skuId,
            });
            return Ok(res);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all target", Description = "")]
        [ProducesResponseType(typeof(List<TargetResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> getAllTarget()
        {
            var query = new GetTargetQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

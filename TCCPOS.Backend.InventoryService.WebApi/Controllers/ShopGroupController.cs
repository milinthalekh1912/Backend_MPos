using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.DeleteShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupName;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopGroupController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ShopGroupController> _logger;
        IConfiguration _config;

        public ShopGroupController(ILogger<ShopGroupController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [Authorize]
        [HttpPost("Create")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(CreateShopGroupCommand), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> createShopGroup([FromBody] CreateShopGroupRequest request)
        {
            var res = await _mediator.Send(new CreateShopGroupCommand
            {
                shopGroupName = request.shopGroupName,
                shopId = request.shopId,
                userId = Identity.GetUserID(),
            });
            return Ok(res);
        }

        [Authorize]
        [HttpGet("GetAllGroup")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(List<GetAllShopGroupResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllShopGroup()
        {
            var res = await _mediator.Send(new GetAllShopGroupQuery());
            return Ok(res);
        }

        [Authorize]
        [HttpGet("GetGroupById")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(GetShopGroupByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getShopGroupById(string shopGroupId)
        {
            var res = await _mediator.Send(new GetShopGroupByIdQuery
            {
                shopGroupId = shopGroupId
            });

            return Ok(res);
        }

        [Authorize]
        [HttpDelete("DeleteGroupId")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(DeleteShopGroupResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> deleteShopGroupById([FromBody] DeleteShopGroupRequest request)
        {
            var res = await _mediator.Send(new DeleteShopGroupCommand
            {
                shopGroupId = request.shopGroupId,
                userId = Identity.GetUserID(),
            });
            return Ok(res);
        }

        [Authorize]
        [HttpPut("UpdateGroupId")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(UpdateGroupResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateGroupId([FromBody] UpdateGroupRequest request)
        {
            var res = await _mediator.Send(new UpdateGroupIdCommand
            {
                shopGroupId = request.shopGroupId,
                userId = Identity.GetUserID(),
                shopGroupName = request.shopGroupName,
                shopList = request.shopList
            });
            return Ok(res);
        }

        [Authorize]
        [HttpGet("getAllShop")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(List<GetAllShopResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllShop()
        {
            var res = await _mediator.Send(new GetAllShopQuery());
            return Ok(res);
        }

        [Authorize]
        [HttpPut("updateGroupName")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(UpdateGroupNameResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateGroupName([FromBody] UpdateGroupNameRequest request)
        {
            var res = await _mediator.Send(new UpdateGroupNameCommand
            {
                shopGroupId = request.shopGroupId,
                shopGroupName = request.shopGroupName,
                userId = Identity.GetUserID(),
            });
            return Ok(res);
        }

        [Authorize]
        [HttpGet("GetTargetGoupById/{shopgroupid}", Name = "GetTargetGroupByShopGroup")]
        [ProducesResponseType(typeof(List<ShopGroupResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> Get(string shopgroupid)
        {
            var query = new GetShopGroupByGroupIDQuery(shopgroupid);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

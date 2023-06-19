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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GroupController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GroupController> _logger;
        IConfiguration _config;

        public GroupController(ILogger<GroupController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [Authorize]
        [HttpPost()]
        [SwaggerOperation(Summary = "Create Group", Description = "")]
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
        [HttpGet()]
        [SwaggerOperation(Summary = "Get all group", Description = "")]
        [ProducesResponseType(typeof(List<GetAllShopGroupResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllShopGroup()
        {
            var res = await _mediator.Send(new GetAllShopGroupQuery());
            return Ok(res);
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get group by id", Description = "")]
        [ProducesResponseType(typeof(GetShopGroupByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getShopGroupById(string id)
        {
            var res = await _mediator.Send(new GetShopGroupByIdQuery
            {
                shopGroupId = id
            });

            return Ok(res);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete group by id", Description = "")]
        [ProducesResponseType(typeof(DeleteShopGroupResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> deleteShopGroupById(string id)
        {
            var res = await _mediator.Send(new DeleteShopGroupCommand
            {
                shopGroupId = id,
                userId = Identity.GetUserID(),
            });
            return Ok(res);
        }

        [Authorize]
        [HttpPut("Detail")]
        [SwaggerOperation(Summary = "Update group detail", Description = "")]
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
        [HttpPut("Name")]
        [SwaggerOperation(Summary = "Update group name", Description = "")]
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
        [HttpGet("Target/{id}")]
        [SwaggerOperation(Summary = "Get target group by id", Description = "")]
        [ProducesResponseType(typeof(List<ShopGroupResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> GetTargetGroupById(string shopgroupid)
        {
            var query = new GetShopGroupByGroupIDQuery(shopgroupid);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

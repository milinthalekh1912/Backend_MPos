using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.DeleteShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupName;
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
        public async Task<IActionResult> createMerchantGroup([FromBody] CreateShopGroupRequest request)
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
        [HttpGet]
        [SwaggerOperation(Summary = "Get all group", Description = "")]
        [ProducesResponseType(typeof(List<GetAllMerchantGroupResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllMerchantGroup()
        {
            var res = await _mediator.Send(new GetAllMerchantGroupQuery());
            return Ok(res);
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get group by id", Description = "")]
        [ProducesResponseType(typeof(GetMerchantGroupByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getMerchantGroupById(string id)
        {
            var res = await _mediator.Send(new GetMerchantGroupByIdQuery
            {
                shopGroupId = id
            });

            return Ok(res);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete group by id", Description = "")]
        [ProducesResponseType(typeof(DeleteMerchantGroupResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> deleteMerchantGroupById(string id)
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
        [ProducesResponseType(typeof(UpdateMerchantGroupResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateMerchantGroupId([FromBody] UpdateGroupRequest request)
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
        [ProducesResponseType(typeof(UpdateMerchantGroupNameResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> updateMerchantGroupName([FromBody] UpdateGroupNameRequest request)
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
        [ProducesResponseType(typeof(List<MerchantGroupResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> GetTargetMerchantGroupById(string shopgroupid)
        {
            var query = new GetMerchantGroupByGroupIDQuery(shopgroupid);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

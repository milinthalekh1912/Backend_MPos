using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Principal;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AllAddressController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AllAddressController> _logger;
        public AllAddressController(ILogger<AllAddressController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "getAllAddress")]
        [ProducesResponseType(typeof(AllAddressResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllAddressQuery {
                shopId = Identity.GetShopID(),
            };
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

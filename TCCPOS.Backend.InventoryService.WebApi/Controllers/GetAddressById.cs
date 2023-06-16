using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCPOS.Backend.InventoryService.WebApi.Controllers;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAddressByIdController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GetAddressByIdController> _logger;

        public GetAddressByIdController(ILogger<GetAddressByIdController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAddressById")]
        [ProducesResponseType(typeof(GetAddressByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Get(String address_id)
        {
            var query = new GetAddressByIdQuery(address_id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
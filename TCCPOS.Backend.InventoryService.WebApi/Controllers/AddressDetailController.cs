using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressDetailController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressDetailController> _logger;
        public AddressDetailController(ILogger<AddressDetailController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [Route("Customer")]
        [SwaggerOperation(Summary = "Get all address of customer", Description = "")]
        [ProducesResponseType(typeof(List<AddressDetailResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllAddressDetail()
        {
            var query = new GetAllAddressDetailQuery
            {
                shopId = Identity.GetMerchantID(),
            };
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("Detail/{id}")]
        [SwaggerOperation(Summary = "Get address detail by addressId", Description = "")]
        [ProducesResponseType(typeof(GetAddressByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAddressById(string id)
        {
            var query = new GetAddressByIdQuery(id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

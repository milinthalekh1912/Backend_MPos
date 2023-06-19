using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SupplierController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSupplier")]
        [ProducesResponseType(typeof(List<SupplierResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> Get()
        {
            var query = new GetSupplierQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}

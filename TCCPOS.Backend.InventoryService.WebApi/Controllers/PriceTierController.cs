using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.PriceTier.Query.GetAllPriceTierGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.DeleteTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PriceTierController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PriceTierController> _logger;
        IConfiguration _config;

        public PriceTierController(ILogger<PriceTierController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [Authorize]
        [HttpGet]
        [Route("PriceTierGroup/All/{supplierId}")]
        [SwaggerOperation(Summary = "Get Price Tier Group By  Supplier ID", Description = "")]
        [ProducesResponseType(typeof(CreateTargetResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetPriceTierGroupBySupplierID(string supplierId)
        {
            var query = new GetAllPriceTierGroupQuery(supplierId);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

    }
}

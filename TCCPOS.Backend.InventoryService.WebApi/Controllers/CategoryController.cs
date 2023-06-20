using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCPOS.Backend.InventoryService.WebApi.Controllers;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory;
using Swashbuckle.AspNetCore.Annotations;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{supplierId}")]
        [ProducesResponseType(typeof(CategoriesListResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Get(String supplierId)
        {
            var query = new GetCategoryQuery(supplierId);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        /*[HttpPost]
        [SwaggerOperation(Summary = "Get Categories List", Description = "")]
        [ProducesResponseType(typeof(GetCategoriesListResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCategoriesListForLineOA()
        {
            var query = new GetCategoriesQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }*/
    }
}
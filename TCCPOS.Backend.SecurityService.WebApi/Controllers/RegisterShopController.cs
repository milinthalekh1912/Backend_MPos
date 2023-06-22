using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterMerchantBackOffice;
using TCCPOS.Backend.SecurityService.Application.Feature.Shop.Command.RegisterShop;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterShopController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RegisterShopController> _logger;
        IConfiguration _config;

        public RegisterShopController(ILogger<RegisterShopController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }


        [Authorize]
        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(RegisterShopCommand), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RegisterShopRequest request)
        {
            if (request.zipcode.Length != 5 || request.phone_number.Length != 10)
            {
                return BadRequest();
            }
            var cmd = new RegisterShopCommand();
            cmd.userId = Identity.GetUserID();
            cmd.priceTierId = request.priceTierId;
            cmd.shop_group_id = request.shop_group_id;
            cmd.shop_name = request.shop_name;
            cmd.address1 = request.address1;
            cmd.address2 = request.address2;
            cmd.address3 = request.address3;
            cmd.zipcode = request.zipcode;
            cmd.phone_number = request.phone_number;
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Route("BackOffice")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(RegisterShopCommand), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterShopBackOffice([FromBody] RegisterShopBackOfficeRequest request)
        {
            var cmd = new RegisterMerchantBackOfficeCommand(request);
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }
    }
}

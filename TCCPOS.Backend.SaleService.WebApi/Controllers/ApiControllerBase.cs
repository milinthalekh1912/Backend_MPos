using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TCCPOS.Backend.SaleService.WebApi.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public ClaimsIdentity Identity
        {
            get
            {
                var iden = HttpContext.User.Identity as ClaimsIdentity;
                if (iden == null) throw new Exception("Invalid identity.");
                return iden;
            }
        }
    }
}

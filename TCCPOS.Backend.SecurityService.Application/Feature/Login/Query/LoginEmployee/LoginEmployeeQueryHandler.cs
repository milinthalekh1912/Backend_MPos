using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using TCCPOS.Backend.SecurityService.Application.Feature.CreateUser.Command.CreateUser;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.LoginEmployee;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.Login
{
    public class LoginEmployeeQueryHandler : IRequestHandler<LoginEmployeeQuery, LoginEmployeeResult>
    {
        private readonly ILogger<LoginEmployeeQueryHandler> _logger;
        ISecurityRepository _repo;
        IConfiguration _config;

        public LoginEmployeeQueryHandler(ILogger<LoginEmployeeQueryHandler> logger, ISecurityRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<LoginEmployeeResult> Handle(LoginEmployeeQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.getUserEmployeeByUsername(request.Username);

            if (user == null) throw SecurityServiceException.SE001;
            if (user.Password != request.Password) throw SecurityServiceException.SE002;
            //SupplierID -> 
            var employee_tennant = await _repo.getEmployeeTenantByTenantId(user.TenantID);
            var supplier = await _repo.getSupplierById(employee_tennant.SupplierID);
            var authclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username ?? ""),
                new Claim(ClaimTypes.System, user.TenantID),
                new Claim("Username",user.Username ?? ""),
                new Claim("UserId",user.TenantID),
                new Claim("MerchantID","ADMIN-" + supplier.supplier_name),
                new Claim("BranchID","ADMIN-" + supplier.supplier_name),
                new Claim("SupplierID",employee_tennant.SupplierID ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = GetToken(authclaims, _config["JWT:ValidIssuer"], _config["JWT:ValidAudience"], _config["JWT:Secret"]);
            var res = new LoginEmployeeResult();
            res.accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return res;
        }

        private JwtSecurityToken GetToken(List<Claim> authclaims, string validissuer, string validaudience, string secret)
        {
            var authsigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                issuer: validissuer,
                audience: validaudience,
                expires: DateTime.UtcNow.AddDays(7),
                claims: authclaims,
                signingCredentials: new SigningCredentials(authsigningkey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}

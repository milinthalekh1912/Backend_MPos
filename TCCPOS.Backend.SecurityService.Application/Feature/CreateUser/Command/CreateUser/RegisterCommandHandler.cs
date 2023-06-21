using System;
using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.Login;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace TCCPOS.Backend.SecurityService.Application.Feature.CreateUser.Command.CreateUser
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {

        private readonly ILogger<RegisterCommandHandler> _logger;
        ISecurityRepository _repo;
        IConfiguration _config;

        public RegisterCommandHandler(ILogger<RegisterCommandHandler> logger, ISecurityRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.getUserByUsername(request.Username);

            if (user != null)
            {
                throw SecurityServiceException.SE017;
            }
            var acc = await _repo.createUserAsync(request.Username, request.Password, null);

            var authclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, acc.username ?? ""),
                new Claim(ClaimTypes.System, acc.id),
                new Claim("Username",acc.username ?? ""),
                new Claim("UserId",acc.id),
                new Claim("MerchantID",acc.shop_id ?? ""),
                new Claim("BranchID",acc.shop_id ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = GetToken(authclaims, _config["JWT:ValidIssuer"], _config["JWT:ValidAudience"], _config["JWT:Secret"]);

            var res = new RegisterResult();
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

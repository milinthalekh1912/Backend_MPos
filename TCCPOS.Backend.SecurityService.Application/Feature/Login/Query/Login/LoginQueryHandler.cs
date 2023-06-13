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

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResult>
    {
        private readonly ILogger<LoginQueryHandler> _logger;
        ISecurityRepository _repo;
        IConfiguration _config;

        public LoginQueryHandler(ILogger<LoginQueryHandler> logger, ISecurityRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<LoginResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.getUserByUsername(request.Username);

            if (user == null) throw SecurityServiceException.SE001;
            if (user.password != request.Password) throw SecurityServiceException.SE002;

            var authclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.username ?? ""),
                new Claim(ClaimTypes.System, user.id),
                new Claim("username",user.username ?? ""),
                new Claim("userId",user.id),
                new Claim("shopId",user.shop_id ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = GetToken(authclaims, _config["JWT:ValidIssuer"], _config["JWT:ValidAudience"], _config["JWT:Secret"]);
            var res = new LoginResult();
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

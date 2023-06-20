using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using TCCPOS.Backend.SecurityService.Application.Feature.CreateUser.Command.CreateUser;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLogin
{
    public class LineLoginCommandHandler : IRequestHandler<LineLoginCommand, LineLoginResult>
    {
        private const string TokenValidateUrl = "https://api.line.me/oauth2/v2.1/userinfo";

        private readonly ILogger<LineLoginCommandHandler> _logger;
        ISecurityRepository _repo;
        IConfiguration _config;

        public LineLoginCommandHandler(ILogger<LineLoginCommandHandler> logger, ISecurityRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<LineLoginResult> Handle(LineLoginCommand request, CancellationToken cancellationToken)
        {
            string jsonResponse;
            var httpClient = new HttpClient();
            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Post, TokenValidateUrl))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", request.accessToken);

                var response = await httpClient.SendAsync(requestMessage);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    jsonResponse = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw SecurityServiceException.SE018;
                }
            }
            LineValidateTokenResult userResult = JsonConvert.DeserializeObject<LineValidateTokenResult>(jsonResponse);

            var user = await _repo.getUserByLineId(userResult.sub);

            if (user == null)
            {
                user = await _repo.createUserAsync(null, null, userResult.sub);
            }

            var authclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.username ?? ""),
                new Claim(ClaimTypes.System, user.id),
                new Claim("Username",user.username ?? ""),
                new Claim("UserId",user.id),
                new Claim("MerchantID",user.shop_id ?? ""),
                new Claim("BranchID",user.shop_id ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = GetToken(authclaims, _config["JWT:ValidIssuer"], _config["JWT:ValidAudience"], _config["JWT:Secret"]);

            var res = new LineLoginResult();
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

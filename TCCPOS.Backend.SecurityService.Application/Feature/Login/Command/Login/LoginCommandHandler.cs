using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Login.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly ILogger<LoginCommandHandler> _logger;
        ISecurityRepository _repo;

        public LoginCommandHandler(ILogger<LoginCommandHandler> logger, ISecurityRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var dtnow = DateTime.Now;

            var acc = await _repo.GetUserAccountByLogin(request.Username);
            if (acc.Password != request.Password)
            {
                acc.FailedCount = (acc.FailedCount ?? 0) + 1;
                await _repo.SaveChangeAsyncWithCommit();
                throw SecurityServiceException.SE002;
            }

            var userlogins = await _repo.GetUserLoginByUserID(acc.UserID);
            if (userlogins.Count == 0) throw SecurityServiceException.SE005;
            var userlogin = userlogins.FirstOrDefault(x => x.POSClientID == request.POSClientID);
            if (userlogin == null) throw SecurityServiceException.SE006;
            var posclient = await _repo.GetPOSClientByID(request.POSClientID); // ทำเพื่อ check ว่า POSClient  ยัง active อยู่ไหม

            acc.FailedCount = 0;
            acc.LastLogin = dtnow;
            userlogin.LastLogin = dtnow;
            userlogin.Version = request.Version; // ใส่ version ของ client เข้าไปเก็บไว้
            await _repo.CreateUserActivity(acc.UserID, request.POSClientID, null, "Login", request.Version, dtnow); // TODO: ถ้ามี shift อยู่แล้วให้เอามาใส่เพิ่ม
            await _repo.SaveChangeAsyncWithCommit();

            var authclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.System, request.POSClientID),
                new Claim("Merchant", posclient.MerchantID),
                new Claim("Branch", posclient.BranchID),
                new Claim("Customer", posclient.CustomerID),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = GetToken(authclaims, request.ConfigJWTValidIssuer, request.ConfigJWTValidAudience, request.ConfigJWTSecret);

            var res = new LoginResult();
            res.Username = request.Username;
            res.Token = new JwtSecurityTokenHandler().WriteToken(token);
            res.Expiration = token.ValidTo;
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

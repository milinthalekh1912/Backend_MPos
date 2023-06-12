using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginWithLine.Command.LoginWithLine;

namespace TCCPOS.Backend.SecurityService.Application.Feature.Login.Command.Login
{
    public class LoginWithLineCommandHandler : IRequestHandler<LoginWithLineCommand, LoginWithLineResult>
    {
        private readonly ILogger<LoginWithLineCommandHandler> _logger;
        ISecurityRepository _repo;

        public LoginWithLineCommandHandler(ILogger<LoginWithLineCommandHandler> logger, ISecurityRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<LoginWithLineResult> Handle(LoginWithLineCommand request, CancellationToken cancellationToken)
        {
            var dtnow = DateTime.Now;
            var checkLoginWith = await _repo.GetThirdPartyUser(request.LoginID);
            var checkUserAccount = await _repo.GetAccountByUserID(checkLoginWith.UserID);
     
            var acc = await _repo.GetUserAccountByLogin(checkUserAccount.Login);
            if (acc.Password != checkUserAccount.Password)
            {
                acc.FailedCount = (acc.FailedCount ?? 0) + 1;
                await _repo.SaveChangeAsyncWithCommit();
                throw SecurityServiceException.SE002;
            }

            var userlogins = await _repo.GetUserLoginByUserID(acc.UserID);

            var checkPOSClientID = userlogins.Last().POSClientID;
            if (userlogins.Count == 0) throw SecurityServiceException.SE005;
            var userlogin = userlogins.FirstOrDefault(x => x.POSClientID == checkPOSClientID);
            if (userlogin == null) throw SecurityServiceException.SE006;
            var posclient = await _repo.GetPOSClientByID(checkPOSClientID); // ทำเพื่อ check ว่า POSClient  ยัง active อยู่ไหม

            acc.FailedCount = 0;
            acc.LastLogin = dtnow;
            userlogin.LastLogin = dtnow;
            userlogin.Version = userlogins.Last().Version; // ใส่ version ของ client เข้าไปเก็บไว้
            await _repo.CreateUserActivity(acc.UserID, checkPOSClientID, null, "Login", userlogin.Version, dtnow); // TODO: ถ้ามี shift อยู่แล้วให้เอามาใส่เพิ่ม
            await _repo.SaveChangeAsyncWithCommit();

            var authclaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, checkUserAccount.Login),
                new Claim(ClaimTypes.System, checkPOSClientID),
                new Claim("Merchant", posclient.MerchantID),
                new Claim("Branch", posclient.BranchID),
                new Claim("Customer", posclient.CustomerID),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = GetToken(authclaims, request.ConfigJWTValidIssuer, request.ConfigJWTValidAudience, request.ConfigJWTSecret);

            var res = new LoginWithLineResult();
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

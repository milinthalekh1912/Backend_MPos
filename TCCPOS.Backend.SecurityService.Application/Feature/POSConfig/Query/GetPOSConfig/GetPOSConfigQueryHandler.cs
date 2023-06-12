using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCCPOS.Backend.SecurityService.Application.Contract;

namespace TCCPOS.Backend.SecurityService.Application.Feature.POSConfig.Query.GetPOSConfig
{
    public class GetPOSConfigQueryHandler : IRequestHandler<GetPOSConfigQuery, POSConfigResult>
    {
        private readonly ILogger<GetPOSConfigQueryHandler> _logger;
        ISecurityRepository _repo;

        public GetPOSConfigQueryHandler(ILogger<GetPOSConfigQueryHandler> logger, ISecurityRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<POSConfigResult> Handle(GetPOSConfigQuery request, CancellationToken cancellationToken)
        {
            var posclient = await _repo.GetPOSClientByID(request.POSClientID);
            var branch = await _repo.GetBranchByID(posclient.BranchID);
            var merchant = await _repo.GetMerchantByID(posclient.MerchantID);
           
            var res = new POSConfigResult();

            res.POSClientID = posclient.POSClientID;
            res.BranchID = posclient.BranchID;
            res.BranchNo = branch.BranchNo;
            res.BranchName = branch.BranchName ?? "";
            res.BranchAddress = branch.BranchAddress;
            res.AccountName = branch.AccountName;
            res.AccountCode = branch.AccountCode;
            res.MerchantID = posclient.MerchantID;
            res.MerchantName = merchant.MerchantName ?? "";
            res.TaxID = merchant.TaxID ?? "";
            res.IsDrawer = posclient.IsDrawer;
            res.IsBarcode = posclient.IsBarcode;

            res.IsCash = posclient.IsCash;
            res.IsQRCode = posclient.IsQRCode;
            res.promtpayNo = branch.AccountCode;
            res.promtpayAccountName = branch.AccountName;
            res.IsPaoTang = posclient.IsPaoTang;
            res.IsTongFah = posclient.IsTongFah;
            res.IsCoupon = posclient.IsCoupon;

            res.SessionType = posclient.SessionType;
            res.BarcodeReaderType = posclient.BarcodeReaderType;
            res.PrinterType = posclient.PrinterType;
            res.IsActive = posclient.IsActive;

            res.POSRunning = posclient.POSRunning;
            res.POSRunningFR = posclient.FRPOSRunning;

            res.IsVat = merchant.IsVat ?? false;
            res.RDNumber = posclient.RDNumber;

            res.Address2 = branch.BranchAddress2 ?? "";
            res.subDistrict = branch.BranchSubdistrict;
            res.district = branch.BranchDistrict;
            res.province = branch.BranchProvince;
            res.zipcode = branch.BranchZipcode;

            res.paymentMode = posclient.paymentMode;

            return res;
        }

        private JwtSecurityToken GetTokenBigC(List<Claim> authclaims, string validissuer, string secret)
        {
            var authsigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var payload = new JwtPayload(validissuer, null, authclaims, null, null, null);
            var header = new JwtHeader(new SigningCredentials(authsigningkey, SecurityAlgorithms.HmacSha256));
            var token = new JwtSecurityToken(header, payload);
            return token;
        }
    }
}

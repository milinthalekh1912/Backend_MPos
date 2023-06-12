using TCCPOS.Backend.SecurityService.Application.Feature.CheckVersion.Query.GetCheckVersion;
using TCCPOS.Backend.SecurityService.Entities;

namespace TCCPOS.Backend.SecurityService.Application.Contract
{
    public interface ISecurityRepository
    {
        Task<useraccount> GetUserAccountByLogin(string username);
        Task<List<userlogin>> GetUserLoginByUserID(string userid);
        Task<userlogin> GetUserLoginByKey(string userid, string posclientid);
        Task<posclient> GetPOSClientByID(string posclientid);
        Task<branch> GetBranchByID(string branchid);
        Task<merchant> GetMerchantByID(string merchantid);

        Task<CheckVersionResult> GetCurrentVersion();

        Task SaveChangeAsyncWithCommit();
        Task CreateUserActivity(string userid, string posclientid, string? possesssionid, string activity, string version, DateTime dtnow);
        Task<third_party_login> GetThirdPartyUser(string userId);
        Task<useraccount> GetAccountByUserID(string userId);
    }
}

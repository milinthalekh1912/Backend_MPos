using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using TCCPOS.Backend.SecurityService.Application.Feature.CheckVersion.Query.GetCheckVersion;
using TCCPOS.Backend.SecurityService.Entities;

namespace TCCPOS.Backend.SecurityService.Infrastructure.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        protected readonly SecurityContext _context;

        public SecurityRepository(SecurityContext context)
        {
            _context = context;
        }

        public async Task<useraccount> GetUserAccountByLogin(string username)
        {
            var acc = await _context.useraccount.FirstOrDefaultAsync(x => x.Login == username);
            if (acc == null) throw SecurityServiceException.SE001;
            if (!acc.IsActive) throw SecurityServiceException.SE003;
            if (acc.AuthType != "P") throw SecurityServiceException.SE004;
            return acc;
        }

        public async Task<List<userlogin>> GetUserLoginByUserID(string userid)
        {
            return await _context.userlogin.Where(x => x.UserID == userid).ToListAsync();
        }
        public async Task<userlogin> GetUserLoginByKey(string userid, string posclientid)
        {
            var userlogin = await _context.userlogin.FirstOrDefaultAsync(x => x.UserID == userid && x.POSClientID == posclientid);
            if (userlogin == null) throw SecurityServiceException.SE014;
            return userlogin;
        }

        public async Task<posclient> GetPOSClientByID(string posclientid)
        {
            var posclient = await _context.posclient.FirstOrDefaultAsync(x => x.POSClientID == posclientid);
            if (posclient == null) throw SecurityServiceException.SE007;
            if (!posclient.IsActive) throw SecurityServiceException.SE008;
            return posclient;
        }

        public async Task SaveChangeAsyncWithCommit()
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                _context.Database.SetCommandTimeout(120);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CheckVersionResult> GetCurrentVersion()
        {
            var c = await _context.currentversion.OrderBy(x => x.MajorVersion).FirstOrDefaultAsync();
            if (c == null) throw SecurityServiceException.SE009;
            return new CheckVersionResult()
            {
                Major = c.MajorVersion,
                Minor = c.MinorVersion ?? 0,
                Build = c.BuildVersion ?? 0
            };
        }

        public async Task CreateUserActivity(string userid, string posclientid, string? possesssionid, string activity, string version, DateTime dtnow)
        {
            var m = new useractivity();
            m.UserID = userid;
            m.POSClientID = posclientid;
            m.POSSessionID = possesssionid;
            m.Activity = activity;
            m.CreateDate = dtnow;
            m.Note1 = version;
            await _context.useractivity.AddAsync(m);
        }

        public async Task<branch> GetBranchByID(string branchid)
        {
            var branch = await _context.branch.FirstOrDefaultAsync(x => x.BranchID == branchid);
            if (branch == null) throw SecurityServiceException.SE010;
            if (!branch.IsActive) throw SecurityServiceException.SE011;
            return branch;
        }

        public async Task<merchant> GetMerchantByID(string merchantid)
        {
            var merchant = await _context.merchant.FirstOrDefaultAsync(x => x.MerchantID == merchantid);
            if (merchant == null) throw SecurityServiceException.SE012;
            if (merchant.IsActive == null || !merchant.IsActive.Value) throw SecurityServiceException.SE013;
            return merchant;
        }
        public async Task<third_party_login> GetThirdPartyUser(string userLogin)
        {
            var third_party_user = await _context.third_party_login.FirstOrDefaultAsync(x => x.LoginID == userLogin);
            if (third_party_user == null) throw SecurityServiceException.SE015;
            return third_party_user;
        }
        public async Task<useraccount> GetAccountByUserID(string userId)
        {
            var useraccount = await _context.useraccount.FirstOrDefaultAsync(x => x.UserID == userId);
            if (useraccount == null) throw SecurityServiceException.SE016;
            return useraccount;
        }
    }
}

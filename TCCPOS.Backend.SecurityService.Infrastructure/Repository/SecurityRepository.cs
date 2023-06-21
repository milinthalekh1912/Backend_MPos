using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using TCCPOS.Backend.SecurityService.Entities;

namespace TCCPOS.Backend.SecurityService.Infrastructure.Repository
{
    public class SecurityRepository : ISecurityRepository
    {
        protected readonly SecurityContext _context;
        DateTime _dtnow;

        public SecurityRepository(SecurityContext context)
        {
            _dtnow = DateTime.Now;
            _context = context;
        }
        public async Task<user> getUserById(string id)
        {
            var acc = await _context.user.FirstOrDefaultAsync(e => e.id == id);
            return acc;
        }

        public async Task<user> getUserByUsername(string username)
        {
            var acc = await _context.user.AsNoTracking().FirstOrDefaultAsync(e => e.username == username);
            return acc;
        }

        public async Task<user> createUserAsync(string username, string password, string line_sub_id)
        {
            string newId = Guid.NewGuid().ToString();
            var newUser = new user
            {
                id = newId,
                line_sub_Id = line_sub_id,
                username = username,
                password = password,
                is_active = true,
                created_by = newId,
                updated_by = newId,
                updated_date = _dtnow,
                created_date = _dtnow,
            };
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<user> getUserByLineId(string lineId)
        {
            var acc = await _context.user.AsNoTracking().FirstOrDefaultAsync(e => e.line_sub_Id == lineId);
            return acc;
        }

        public async Task<merchant> createShopAsync(string shop_name, string priceTierId, string shop_group_id, string userId)
        {
            var newShop = new merchant
            {
                merchant_id = Guid.NewGuid().ToString(),
                merchant_name = shop_name,
                price_tier_id = priceTierId,
                merchant_group_id = shop_group_id,
                created_by = userId,
                updated_by = userId,
                updated_date = _dtnow,
                created_date = _dtnow,
            };

            await _context.AddAsync(newShop);
            await _context.SaveChangesAsync();
            return newShop;
        }

        public async Task<merchantaddress> createNewShopAddress(string shopId, string shop_name, string address1, string address2, string address3, string zipcode, string phone_number, string userId)
        {
            var newShopAddress = new merchantaddress
            {
                merchant_id = shopId,
                address_id = Guid.NewGuid().ToString(),
                address_title = shop_name,
                address1 = address1,
                address2 = address2,
                address3 = address3,
                zipcode = zipcode,
                phone_number = phone_number,
                created_by = userId,
                updated_by = userId,
                created_date = _dtnow,
                updated_date = _dtnow,
            };

            await _context.AddAsync(newShopAddress);
            await _context.SaveChangesAsync();

            return newShopAddress;
        }

        public async Task<user> updateUserShopId(string id, string shopId)
        {
            var user = await getUserById(id);
            user.shop_id = shopId;

            await _context.SaveChangesAsync();

            return user;
        }



        //public async Task<useraccount> LoginWithUsername(string username,string password)
        //{
        //}

        //public async Task<useraccount> GetUserAccountByLogin(string username)
        //{
        //    var acc = await _context.useraccount.FirstOrDefaultAsync(x => x.Login == username);
        //    if (acc == null) throw SecurityServiceException.SE001;
        //    if (!acc.IsActive) throw SecurityServiceException.SE003;
        //    if (acc.AuthType != "P") throw SecurityServiceException.SE004;
        //    return acc;
        //}

        //public async Task<List<userlogin>> GetUserLoginByUserID(string userid)
        //{
        //    return await _context.userlogin.Where(x => x.UserID == userid).ToListAsync();
        //}

        //public async Task<posclient> GetPOSClientByID(string posclientid)
        //{
        //    var posclient = await _context.posclient.FirstOrDefaultAsync(x => x.POSClientID == posclientid);
        //    if (posclient == null) throw SecurityServiceException.SE007;
        //    if (!posclient.IsActive) throw SecurityServiceException.SE008;
        //    return posclient;
        //}

        //public async Task SaveChangeAsyncWithCommit()
        //{
        //    if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
        //    {
        //        _context.Database.SetCommandTimeout(120);
        //    }
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<CheckVersionResult> GetCurrentVersion()
        //{
        //    var c = await _context.currentversion.OrderBy(x => x.MajorVersion).FirstOrDefaultAsync();
        //    if (c == null) throw SecurityServiceException.SE009;
        //    return new CheckVersionResult()
        //    {
        //        Major = c.MajorVersion,
        //        Minor = c.MinorVersion ?? 0,
        //        Build = c.BuildVersion ?? 0
        //    };
        //}

        //public async Task CreateUserActivity(string userid, string posclientid, string? possesssionid, string activity, string version, DateTime dtnow)
        //{
        //    var m = new useractivity();
        //    m.UserID = userid;
        //    m.POSClientID = posclientid;
        //    m.POSSessionID = possesssionid;
        //    m.Activity = activity;
        //    m.CreateDate = dtnow;
        //    m.Note1 = version;
        //    await _context.useractivity.AddAsync(m);
        //}

        //public async Task<branch> GetBranchByID(string branchid)
        //{
        //    var branch = await _context.branch.FirstOrDefaultAsync(x => x.BranchID == branchid);
        //    if (branch == null) throw SecurityServiceException.SE010;
        //    if (!branch.IsActive) throw SecurityServiceException.SE011;
        //    return branch;
        //}

        //public async Task<merchant> GetMerchantByID(string merchantid)
        //{
        //    var merchant = await _context.merchant.FirstOrDefaultAsync(x => x.MerchantID == merchantid);
        //    if (merchant == null) throw SecurityServiceException.SE012;
        //    if (merchant.IsActive == null || !merchant.IsActive.Value) throw SecurityServiceException.SE013;
        //    return merchant;
        //}
        //public async Task<third_party_login> GetThirdPartyUser(string userLogin)
        //{
        //    var third_party_user = await _context.third_party_login.FirstOrDefaultAsync(x => x.LoginID == userLogin);
        //    if (third_party_user == null) throw SecurityServiceException.SE015;
        //    return third_party_user;
        //}
        //public async Task<useraccount> GetAccountByUserID(string userId)
        //{
        //    var useraccount = await _context.useraccount.FirstOrDefaultAsync(x => x.UserID == userId);

        //    if (useraccount == null) throw SecurityServiceException.SE016;
        //    return useraccount;
        //}
    }
}

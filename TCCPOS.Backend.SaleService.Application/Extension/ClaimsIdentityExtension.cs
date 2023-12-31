﻿using System.Security.Claims;

namespace System
{
    public static class ClaimsIdentityExtension
    {
        public static string GetUsername(this ClaimsIdentity iden)
        {
            var claim = iden.FindFirst(ClaimTypes.Name);
            if (claim == null) throw new Exception("");
            return claim.Value;
        }
        public static string GetPOSClientID(this ClaimsIdentity iden)
        {
            var claim = iden.FindFirst(ClaimTypes.System);
            if (claim == null) throw new Exception("");
            return claim.Value;
        }
        public static string GetMerchantID(this ClaimsIdentity iden)
        {
            var claim = iden.FindFirst("Merchant");
            if (claim == null) throw new Exception("");
            return claim.Value;
        }
        public static string GetBranchID(this ClaimsIdentity iden)
        {
            var claim = iden.FindFirst("Branch");
            if (claim == null) throw new Exception("");
            return claim.Value;
        }
    }
}

using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class sku_branch_price
    {
        public string SKUID { get; set; } = null!;
        public string MerchantID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public decimal? Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public sbyte IsActive { get; set; }
    }
}

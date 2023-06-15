using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class branch
    {
        public string BranchID { get; set; } = null!;
        public string? MerchantID { get; set; }
        public string? BranchNo { get; set; }
        public string? BranchAddress { get; set; }
        public string? BranchAddress2 { get; set; }
        public string? AccountName { get; set; }
        public string? AccountCode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchEmail { get; set; }
        public string? BranchSubdistrict { get; set; }
        public string? BranchDistrict { get; set; }
        public string? BranchProvince { get; set; }
        public string? BranchZipcode { get; set; }
        public sbyte? IsShippingUsual { get; set; }
        public sbyte? IsShippingExpress { get; set; }
        public bool IsActive { get; set; }
    }
}

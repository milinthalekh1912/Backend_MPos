using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class customer
    {
        public string CustomerID { get; set; } = null!;
        public int? CustomerType { get; set; }
        public string? Name { get; set; }
        public string? TaxID { get; set; }
        public string? BranchNo { get; set; }
        public string? Mobile { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? MerchantID { get; set; }
        public string? BranchID { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

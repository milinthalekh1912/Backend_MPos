using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class merchant
    {
        public string MerchantID { get; set; } = null!;
        public string? MerchantName { get; set; }
        public string? MerchantAddress { get; set; }
        public string? MerchantTel { get; set; }
        public string? TaxID { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVat { get; set; }
    }
}

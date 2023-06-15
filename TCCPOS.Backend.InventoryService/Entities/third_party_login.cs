using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class third_party_login
    {
        public string LoginID { get; set; } = null!;
        public string UserID { get; set; } = null!;
        public string? ProviderName { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}

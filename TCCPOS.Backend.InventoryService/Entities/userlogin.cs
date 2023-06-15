using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class userlogin
    {
        public string UserID { get; set; } = null!;
        public string? POSClientID { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public string? Version { get; set; }
    }
}

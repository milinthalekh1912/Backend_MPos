using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class useractivity
    {
        public int UAID { get; set; }
        public string? UserID { get; set; }
        public string? POSClientID { get; set; }
        public string? POSSessionID { get; set; }
        public string? Activity { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Note1 { get; set; }
    }
}

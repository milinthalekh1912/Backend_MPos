using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class employeetenant
    {
        public int TanantID { get; set; }
        public string? AgentName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}

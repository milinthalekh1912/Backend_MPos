using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class employeetenant
    {
        public string TanantID { get; set; } = null!;
        public string SupplierID { get; set; } = null!;
        public string? AgentName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}

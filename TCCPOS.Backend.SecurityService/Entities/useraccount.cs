using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class useraccount
    {
        public string UserID { get; set; } = null!;
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? AuthType { get; set; }
        public string? UserType { get; set; }
        public int? FailedCount { get; set; }
        public string? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}

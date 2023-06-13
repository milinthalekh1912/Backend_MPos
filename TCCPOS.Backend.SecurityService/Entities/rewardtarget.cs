using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class rewardtarget
    {
        public string reward_id { get; set; } = null!;
        public string? shop_group_id { get; set; }
        public int? target { get; set; }
        public string? sku_id { get; set; }
        public string? reward { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
    }
}

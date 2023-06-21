using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class point
    {
        public int point1 { get; set; }
        public string shop_id { get; set; } = null!;
        public DateTime exp_date { get; set; }
        public DateTime created_date { get; set; }
        public string created_by { get; set; } = null!;
    }
}

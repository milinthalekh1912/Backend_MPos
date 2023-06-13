using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class shopgroup
    {
        public string shop_group_id { get; set; } = null!;
        public string? group_name { get; set; }
    }
}

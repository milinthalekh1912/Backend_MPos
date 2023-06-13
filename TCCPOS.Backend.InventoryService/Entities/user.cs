using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class user
    {
        public string id { get; set; } = null!;
        public string? line_sub_Id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? authtype { get; set; }
        public string? usertype { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }
        public string? shop_id { get; set; }
        public bool? is_active { get; set; }
    }
}

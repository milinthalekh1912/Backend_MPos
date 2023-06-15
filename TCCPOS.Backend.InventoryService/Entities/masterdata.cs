using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class masterdata
    {
        public masterdata()
        {
            orderitem = new HashSet<orderitem>();
            pricetier = new HashSet<pricetier>();
            rewardtarget = new HashSet<rewardtarget>();
        }

        public string sku_id { get; set; } = null!;
        public string? title { get; set; }
        public string? alias_title { get; set; }
        public string? barcode { get; set; }
        public string? image_url { get; set; }
        public string? category_id { get; set; }
        public string? supplier_id { get; set; }
        public string? unit_id { get; set; }
        public DateTime? created_date { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_date { get; set; }
        public string? updated_by { get; set; }

        public virtual category? category { get; set; }
        public virtual supplier? supplier { get; set; }
        public virtual unit? unit { get; set; }
        public virtual ICollection<orderitem> orderitem { get; set; }
        public virtual ICollection<pricetier> pricetier { get; set; }
        public virtual ICollection<rewardtarget> rewardtarget { get; set; }
    }
}

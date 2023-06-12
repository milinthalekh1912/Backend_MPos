using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class sku
    {
        public string? SKUID { get; set; }
        public string? Barcode { get; set; }
        public string? Title { get; set; }
        public string? AliasTitle { get; set; }
        public int? BrandID { get; set; }
        public int? ProductCategoryID { get; set; }
        public int? ProductSizeID { get; set; }
        public int? ProductUnit { get; set; }
        public string? PackSize { get; set; }
        public int? Unit { get; set; }
        public int? BanForPracharat { get; set; }
        public bool? IsVat { get; set; }
        public string? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public string? MerchantID { get; set; }
        public string? MapSKU { get; set; }
        public bool IsFixPrice { get; set; }
    }
}

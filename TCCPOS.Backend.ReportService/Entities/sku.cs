namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class sku
    {
        public string SKUID { get; set; } = null!;
        public string BarcodePOS { get; set; } = null!;
        public string? ProductName { get; set; }
        public int? BrandID { get; set; }
        public int? ProductGroupID { get; set; }
        public int? ProductCatID { get; set; }
        public int? ProductSubCatID { get; set; }
        public int? ProductSizeID { get; set; }
        public int? ProductUnit { get; set; }
        public string? PackSize { get; set; }
        public int? Unit { get; set; }
        public int? BanForPracharat { get; set; }
        public bool? IsVat { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public string? MerchantID { get; set; }
        public string? MapSKU { get; set; }
        public bool IsFixPrice { get; set; }
    }
}

namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class raw_product_master
    {
        public string id { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public string? Barcode_POS { get; set; }
        public string? Product_Name { get; set; }
        public string? TH_Brand { get; set; }
        public string? TH_ProdGroup { get; set; }
        public string? TH_ProdCat { get; set; }
        public string? EN_Brand { get; set; }
        public string? EN_ProdGroup { get; set; }
        public string? EN_ProdCat { get; set; }
        public string? Updated_Price { get; set; }
        public string? UpdateDate { get; set; }
        public string? Product_Size { get; set; }
        public string? ProductUnit { get; set; }
        public string? pack_size { get; set; }
        public string? Unit { get; set; }
        public string? Is_TBEV { get; set; }
        public string? Product_Source_Label { get; set; }
        public string? IS_B2B_1000 { get; set; }
        public string? IS_193 { get; set; }
        public string? Source { get; set; }
        public string? Update_Product_Name { get; set; }
        public int? BrandID { get; set; }
        public int? ProdcatID { get; set; }
        public int? ProdgroupID { get; set; }
        public int? ProdsizeID { get; set; }
        public int? produnitid { get; set; }

        public virtual brand? Brand { get; set; }
        public virtual prodcat? Prodcat { get; set; }
        public virtual prodgroup? Prodgroup { get; set; }
        public virtual prodsize? Prodsize { get; set; }
        public virtual produnit? produnit { get; set; }
    }
}

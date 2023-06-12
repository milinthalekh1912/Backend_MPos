namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class saleitem
    {
        public string SaleItemID { get; set; } = null!;
        public string SaleOrderID { get; set; } = null!;
        public int Seq { get; set; }
        public string SKUID { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal? FullPrice { get; set; }
        public decimal BeforeVatSale { get; set; }
        public decimal? AfterVatSale { get; set; }
        public string POSClientID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string? CompCode { get; set; }
        public int? PromotionID { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public sbyte? VoidType { get; set; }
        public string? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }
    }
}

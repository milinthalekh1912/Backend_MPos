namespace TCCPOS.Backend.ReportService.Entities
{
    /// <summary>
    /// Sale Order
    /// </summary>
    public partial class saleorder
    {
        public string SaleOrderID { get; set; } = null!;
        public string? DocNo { get; set; }
        public string POSSessionID { get; set; } = null!;
        public decimal BeforeVATSale { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal VATSale { get; set; }
        public decimal TotalSale { get; set; }
        public string POSClientID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string MerchantID { get; set; } = null!;
        public string? MemberID { get; set; }
        public sbyte Status { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public sbyte? VoidType { get; set; }
        public string? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }
    }
}

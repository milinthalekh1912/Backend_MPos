namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class fulltax
    {
        public string FullTaxID { get; set; } = null!;
        public string SaleOrderID { get; set; } = null!;
        public string ReceiptNo { get; set; } = null!;
        public string FullReceiptNo { get; set; } = null!;
        public string RDNumber { get; set; } = null!;
        public string MerchantID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string BranchNo { get; set; } = null!;
        public string CustomerID { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string CustomerTaxID { get; set; } = null!;
        public string? CustomerBranchNo { get; set; }
        public sbyte DocumentStatus { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}

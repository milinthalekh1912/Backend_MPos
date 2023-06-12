namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class customer
    {
        public string CustomerID { get; set; } = null!;
        public sbyte CustomerType { get; set; }
        public string Name { get; set; } = null!;
        public string TaxID { get; set; } = null!;
        public string? BranchNo { get; set; }
        public string? Mobile { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string MerchantID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
    }
}

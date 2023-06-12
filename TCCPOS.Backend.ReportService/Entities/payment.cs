namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class payment
    {
        public string PaymentID { get; set; } = null!;
        public string SaleOrderID { get; set; } = null!;
        public int Seq { get; set; }
        public sbyte PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountRecieve { get; set; }
        public string? POSSessionID { get; set; }
        public string POSClientID { get; set; } = null!;
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public sbyte? VoidType { get; set; }
        public string? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }
    }
}

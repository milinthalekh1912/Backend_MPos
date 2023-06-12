namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class payment_promptpay
    {
        public string PaymentID { get; set; } = null!;
        public string? BankAccount { get; set; }
        public string? Ref1 { get; set; }
        public string? Ref2 { get; set; }
        public decimal? Amount { get; set; }
    }
}

namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class payment_method
    {
        public int PaymentMethodID { get; set; }
        public string PaymentName { get; set; } = null!;
    }
}

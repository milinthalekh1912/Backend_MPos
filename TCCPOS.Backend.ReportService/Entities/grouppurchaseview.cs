
namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class grouppurchaseview
    {
        public string POSClientID { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
        public string PaymentName { get; set; } = null!;
        public string? MerchantName { get; set; }
        public string? BranchName { get; set; }
        public decimal? Amount { get; set; }
    }
}

namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class payment_coupon
    {
        public string PaymentID { get; set; } = null!;
        public string CouponFrom { get; set; } = null!;
        public string CounponCode { get; set; } = null!;
        public sbyte? CouponType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; } = null!;
        public decimal? Amount { get; set; }
        public string? SKUID { get; set; }
        public decimal Percent { get; set; }
    }
}

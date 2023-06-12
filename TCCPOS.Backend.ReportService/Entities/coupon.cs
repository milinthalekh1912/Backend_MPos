namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class coupon
    {
        public string CouponCode { get; set; } = null!;
        public sbyte? CouponType { get; set; }
        public int? Seq { get; set; }
        public DateTime? UseDate { get; set; }
    }
}

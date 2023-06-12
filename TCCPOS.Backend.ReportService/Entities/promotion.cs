namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class promotion
    {
        public int PromotionID { get; set; }
        public int PromotionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = null!;
        public string Conditions { get; set; } = null!;
    }
}

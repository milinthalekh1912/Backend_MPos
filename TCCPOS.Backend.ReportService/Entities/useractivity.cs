namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class useractivity
    {
        public int UAID { get; set; }
        public string UserID { get; set; } = null!;
        public string POSClientID { get; set; } = null!;
        public string? POSSessionID { get; set; }
        public string Activity { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? Note1 { get; set; }
    }
}

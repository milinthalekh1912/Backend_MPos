
namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class customer_address
    {
        public string CustomerID { get; set; } = null!;
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Subdistrict { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? Zipcode { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
    }
}

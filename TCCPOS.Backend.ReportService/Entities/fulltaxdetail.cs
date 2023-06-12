
namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class fulltaxdetail
    {
        public string FullTaxID { get; set; } = null!;
        public string BranchAddress1 { get; set; } = null!;
        public string? BranchAddress2 { get; set; }
        public string BranchSubdistrict { get; set; } = null!;
        public string BranchDistrict { get; set; } = null!;
        public string BranchProvince { get; set; } = null!;
        public string BranchZipcode { get; set; } = null!;
        public string CustomerAddress1 { get; set; } = null!;
        public string? CustomerAddress2 { get; set; }
        public string CustomerSubdistrict { get; set; } = null!;
        public string CustomerDistrict { get; set; } = null!;
        public string CustomerProvince { get; set; } = null!;
        public string CustomerZipcode { get; set; } = null!;
        public string? Reason { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}

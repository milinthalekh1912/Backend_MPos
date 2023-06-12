
namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class subdistricts
    {
        public string id { get; set; } = null!;
        public int zip_code { get; set; }
        public string name_th { get; set; } = null!;
        public string name_en { get; set; } = null!;
        public int district_id { get; set; }
    }
}

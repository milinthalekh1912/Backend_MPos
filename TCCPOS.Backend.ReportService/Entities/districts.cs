
namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class districts
    {
        public int id { get; set; }
        public string code { get; set; } = null!;
        public string name_th { get; set; } = null!;
        public string name_en { get; set; } = null!;
        public int province_id { get; set; }
    }
}

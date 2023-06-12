namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class provinces
    {
        public int id { get; set; }
        public string code { get; set; } = null!;
        public string name_th { get; set; } = null!;
        public string name_en { get; set; } = null!;
        public int geography_id { get; set; }
    }
}

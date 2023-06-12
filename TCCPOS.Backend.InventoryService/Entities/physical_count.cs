namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class physical_count
    {
        public string PhysicalCountID { get; set; } = null!;
        public string? BranchID { get; set; }
        public string BranchLocationID { get; set; } = null!;
        public string PhysicalCountNo { get; set; } = null!;
        public DateTime CountedStartDate { get; set; }
        public DateTime CountedEndDate { get; set; }
        public string? Notes { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

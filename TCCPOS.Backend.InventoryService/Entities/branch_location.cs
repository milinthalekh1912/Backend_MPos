namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class branch_location
    {
        public string ID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ParentID { get; set; }
        public string Type { get; set; } = null!;
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public int? Priority { get; set; }
    }
}

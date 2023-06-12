namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class sku_branch_location
    {
        public string ShelfID { get; set; } = null!;
        public string? ZoneID { get; set; }
        public string LevelID { get; set; } = null!;
        public string? Description { get; set; }
        public string? BranchID { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public sbyte? IsActvie { get; set; }
    }
}

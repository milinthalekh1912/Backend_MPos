namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class movement_header
    {
        public string movement_doc_no { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public sbyte? MovementType { get; set; }
        public string? Location_src { get; set; }
        public string? Location_des { get; set; }
        public sbyte? Status_before { get; set; }
        public sbyte? Status_after { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? Note { get; set; }
    }
}

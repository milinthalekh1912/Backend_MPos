namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class mmdoc
    {
        public string MMDocNo { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public sbyte? MovementType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; } = null!;
    }
}

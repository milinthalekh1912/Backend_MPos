namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class mmstatus
    {
        public int MMStatusID { get; set; }
        public string Description { get; set; } = null!;
        public bool? IsLocationProcess { get; set; }
        public bool? IsUpdateStatusProcess { get; set; }
    }
}

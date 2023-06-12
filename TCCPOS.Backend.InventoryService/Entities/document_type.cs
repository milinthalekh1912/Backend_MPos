namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class document_type
    {
        public int DocumentID { get; set; }
        public string DocumentName { get; set; } = null!;
        public bool? IsVat { get; set; }
    }
}

namespace TCCPOS.Backend.InventoryService.Application.Exceptions
{
    public class InventoryServiceException : ApplicationException
    {
        public static InventoryServiceException IE001 { get; } = new InventoryServiceException(nameof(IE001), "");
        public static InventoryServiceException IE002 { get; } = new InventoryServiceException(nameof(IE002), "Not Found Sku Inventory Branch Config Data");
        public static InventoryServiceException IE003 { get; } = new InventoryServiceException(nameof(IE003), "Document Number Duplicate");
        public static InventoryServiceException IE004 { get; } = new InventoryServiceException(nameof(IE004), "Not Found SkuID in Sku Branch Inventory");
        public static InventoryServiceException IE005 { get; } = new InventoryServiceException(nameof(IE005), "Stock not enough");
        public static InventoryServiceException IE006 { get; } = new InventoryServiceException(nameof(IE006), "Not Found Docment Number");
        public static InventoryServiceException IE007 { get; } = new InventoryServiceException(nameof(IE007), "Not Found Branch Location");
        public static InventoryServiceException IE008 { get; } = new InventoryServiceException(nameof(IE008), "Not Update Branch Location");
        public static InventoryServiceException IE009 { get; } = new InventoryServiceException(nameof(IE009), "Please Take Items Out From Location");
        public static InventoryServiceException IE010 { get; } = new InventoryServiceException(nameof(IE010), "Not Found Location");
        public static InventoryServiceException IE011 { get; } = new InventoryServiceException(nameof(IE011), "Please Take Child Location Out From Parent Location");

        public string Code { get; set; }
        public string Message { get; set; }
        private InventoryServiceException(string code) : base()
        {
            Code = code;
        }
        private InventoryServiceException(string code, string message) : base(message)
        {
            Code = code;
            Message = message;
        }
        private InventoryServiceException(string code, string message, Exception innerexception) : base(message, innerexception)
        {
            Code = code;
        }

    }
}

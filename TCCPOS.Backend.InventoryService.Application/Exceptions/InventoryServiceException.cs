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
        public static InventoryServiceException IE012 { get; } = new InventoryServiceException(nameof(IE012), "User Already Have Merchant Group");
        public static InventoryServiceException IE013 { get; } = new InventoryServiceException(nameof(IE013), "MerchantGroup does not exist");
        public static InventoryServiceException IE014 { get; } = new InventoryServiceException(nameof(IE014), "Already have This Sku in Merchant Group");
        public static InventoryServiceException IE015 { get; } = new InventoryServiceException(nameof(IE015), "Reward Target Not found");
        public static InventoryServiceException IE016 { get; } = new InventoryServiceException(nameof(IE016), "Sku Not found");
        public static InventoryServiceException IE017 { get; } = new InventoryServiceException(nameof(IE017), "Supplier Not Found");
        public static InventoryServiceException IE018 { get; } = new InventoryServiceException(nameof(IE018), "Order Not Found");
        public static InventoryServiceException IE019 { get; } = new InventoryServiceException(nameof(IE019), "Order Status Invalid");

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

namespace TCCPOS.Backend.SaleService.Application.Exceptions
{
    public class SaleServiceException : ApplicationException
    {
        public static SaleServiceException SA001 { get; } = new SaleServiceException(nameof(SA001), "Username not found.");
        public static SaleServiceException SA003 { get; } = new SaleServiceException(nameof(SA003), "Username is inactive.");
        public static SaleServiceException SA007 { get; } = new SaleServiceException(nameof(SA007), "Invalid POSClient ID.");
        public static SaleServiceException SA008 { get; } = new SaleServiceException(nameof(SA008), "POSClient is inactive.");
        public static SaleServiceException SA009 { get; } = new SaleServiceException(nameof(SA009), "There is no opening shift in this POSClient.");
        public static SaleServiceException SA010 { get; } = new SaleServiceException(nameof(SA010), "A shift already open.");
        public static SaleServiceException SA011 { get; } = new SaleServiceException(nameof(SA011), "There is no opening shift.");
        public static SaleServiceException SA012 { get; } = new SaleServiceException(nameof(SA012), "Invalid SKU ID.");
        public static SaleServiceException SA013 { get; } = new SaleServiceException(nameof(SA013), "Invalid SaleOrder ID.");
        public static SaleServiceException SA014 { get; } = new SaleServiceException(nameof(SA014), "SaleOrder is inactive.");
        public static SaleServiceException SA015 { get; } = new SaleServiceException(nameof(SA015), "Invalid Payment ID.");
        public static SaleServiceException SA016 { get; } = new SaleServiceException(nameof(SA016), "Invalid SaleItem ID.");
        public static SaleServiceException SA017 { get; } = new SaleServiceException(nameof(SA017), "Invalid ProductCat ID.");
        public static SaleServiceException SA018 { get; } = new SaleServiceException(nameof(SA018), "Invalid ProductGroup ID.");
        public static SaleServiceException SA019 { get; } = new SaleServiceException(nameof(SA019), "Invalid date.");
        public static SaleServiceException SA020 { get; } = new SaleServiceException(nameof(SA020), "Invalid Brand ID.");
        public static SaleServiceException SA021 { get; } = new SaleServiceException(nameof(SA021), "Invalid ProductSubCat ID.");
        public static SaleServiceException SA022 { get; } = new SaleServiceException(nameof(SA022), "Invalid Coupon Code.");
        public static SaleServiceException SA023 { get; } = new SaleServiceException(nameof(SA023), "Coupon already used.");
        public static SaleServiceException SA024 { get; } = new SaleServiceException(nameof(SA024), "Invalid CouponType.");
        public static SaleServiceException SA025(string message)
        {
            return new SaleServiceException(nameof(SA025), message); // Duplicate entry
        }
        public static SaleServiceException SA026 { get; } = new SaleServiceException(nameof(SA026), "Invalid date.");
        public static SaleServiceException SA027 { get; } = new SaleServiceException(nameof(SA027), "Product category not found.");
        public static SaleServiceException SA028 { get; } = new SaleServiceException(nameof(SA028), "Product group not found.");
        public static SaleServiceException SA029 { get; } = new SaleServiceException(nameof(SA029), "Invalid Search String.");

        public static SaleServiceException SA030 { get; } = new SaleServiceException(nameof(SA030), "No Promotion Apply");
        public static SaleServiceException SA031 { get; } = new SaleServiceException(nameof(SA031), "Barcode too long.");
        public static SaleServiceException SA032 { get; } = new SaleServiceException(nameof(SA032), "Favorite full order!.");
        public string Code { get; set; }
        private SaleServiceException(string code) : base()
        {
            Code = code;
        }
        private SaleServiceException(string code, string message) : base(message)
        {
            Code = code;
        }
        private SaleServiceException(string code, string message, Exception innerexception) : base(message, innerexception)
        {
            Code = code;
        }

    }
}

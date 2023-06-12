using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class posclient
    {
        public string POSClientID { get; set; } = null!;
        public string? BranchID { get; set; }
        public string? CustomerID { get; set; }
        public string? MerchantID { get; set; }
        public string? RDNumber { get; set; }
        public bool? IsDrawer { get; set; }
        public bool? IsBarcode { get; set; }
        public bool? IsCash { get; set; }
        public bool? IsQRCode { get; set; }
        public bool? IsPaoTang { get; set; }
        public bool? IsTongFah { get; set; }
        public bool? IsCoupon { get; set; }
        public sbyte? SessionType { get; set; }
        public sbyte? BarcodeReaderType { get; set; }
        public sbyte? PrinterType { get; set; }
        public bool IsActive { get; set; }
        public string? POSRunning { get; set; }
        public string? FRPOSRunning { get; set; }
        public sbyte? paymentMode { get; set; }
    }
}

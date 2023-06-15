using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class payment
    {
        public string? PaymentID { get; set; }
        public string? SaleOrderID { get; set; }
        public int Seq { get; set; }
        public sbyte PaymentMethod { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountRecieve { get; set; }
        public string? POSClientID { get; set; }
        public string? BranchID { get; set; }
        public string? MerchantID { get; set; }
        public string? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte? VoidType { get; set; }
        public string? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }
    }
}

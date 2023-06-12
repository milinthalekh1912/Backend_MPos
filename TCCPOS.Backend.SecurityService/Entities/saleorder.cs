using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class saleorder
    {
        public string? SaleOrderID { get; set; }
        public string? DocNo { get; set; }
        public string? POSSessionID { get; set; }
        public decimal? BeforeVAT { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal? VATSale { get; set; }
        public decimal? TotalSale { get; set; }
        public string? POSClientID { get; set; }
        public string? BranchID { get; set; }
        public string? MerchantID { get; set; }
        public string? MemberID { get; set; }
        public string? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public sbyte IsActive { get; set; }
        public sbyte? VoidType { get; set; }
        public string? VoidBy { get; set; }
        public DateTime? VoidDate { get; set; }
    }
}

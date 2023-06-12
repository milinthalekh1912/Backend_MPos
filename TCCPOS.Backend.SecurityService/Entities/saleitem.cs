using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class saleitem
    {
        public string? SaleItemID { get; set; }
        public string? SaleOrderID { get; set; }
        public int Seq { get; set; }
        public string? SKUID { get; set; }
        public string? Barcode { get; set; }
        public string? Title { get; set; }
        public string? AliasTitle { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? FullPrice { get; set; }
        public decimal? BeforeVat { get; set; }
        public decimal? AfterVat { get; set; }
        public string? CompCode { get; set; }
        public int? PromotionID { get; set; }
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

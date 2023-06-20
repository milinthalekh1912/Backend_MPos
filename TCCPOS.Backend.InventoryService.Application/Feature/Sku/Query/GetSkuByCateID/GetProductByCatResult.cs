using System;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat
{
    public class GetProductByCatResult
    {
        public string? title { get; set; }
        public string? aliasTitle { get; set; }
        public string? sku { get; set; }
        public string? barcode { get; set; }
        //public double? price { get; set; }
        public string? imageUrl { get; set; }
        public string categoryId { get; set; }
    }
}
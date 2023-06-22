using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuBySupplierId
{
    public class GetAllSkuItemResult
    {
        public string? title { get; set; }
        public string? aliasTitle { get; set; }
        public string? sku { get; set; }
        public string? barcode { get; set; }
        public string? imageUrl { get; set; }
        public string? categoryId { get; set; }
        public string? unitTitle { get; set; }
        public double? price { get; set; }
    }
}

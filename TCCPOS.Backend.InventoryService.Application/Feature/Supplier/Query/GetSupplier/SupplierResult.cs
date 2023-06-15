using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier
{
    public class SupplierResult
    {
        public string? shopId { get; set; }
        public string? shopTitle { get; set; }
        public string? shopImageUrl { get; set; }
        public bool isPriceShow { get; set; }
        public bool? isStockShow { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuBySupplierId
{
    public class GetAllSkuResult
    {
        public List<GetAllSkuItemResult> item { get; set; } = new List<GetAllSkuItemResult>();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory
{
    public class CategoriesListResult
    {
        public List<CategoryResult> items { get; set; } = new List<CategoryResult>();
    }
}

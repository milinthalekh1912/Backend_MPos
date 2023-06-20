using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.InventoryService.Application.Feature.SKU.Query.GetSkuListByCategoriesID
{
    public class SkuItemResult
    {
        public string SkuID { get; set; }
        public string Title { get; set; }
        public string AliasTitle { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

    }
}

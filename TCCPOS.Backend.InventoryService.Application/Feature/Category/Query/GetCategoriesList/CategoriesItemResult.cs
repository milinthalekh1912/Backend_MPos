using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Categories.Query.GetCategoriesList
{
    public class CategoriesItemResult
    {
        public string CategoriesID { get; set; }
        public string TH_Title { get; set; }
        public string EN_Title { get; set; }
        public string TH_Description { get; set; }
        public string EN_Description { get; set; }
        public string UrlImg { get; set; }

    }
}
namespace TCCPOS.Backend.InventoryService.Application.Feature.Categories.Query.GetCategoriesList
{
    public class GetCategoriesListResult
    {
        public List<CategoriesItemResult> items { get; set; } = new List<CategoriesItemResult>();
    }
}

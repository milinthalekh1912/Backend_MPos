using TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ICategoriesRepository
    {
        Task SaveChangeAsyncWithCommit();
        Task<List<CategoryResult>> GetCategoryBySupplierIdAsync(string supplier_id);

    }
}

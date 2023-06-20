using TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ICategoriesRepository
    {
        Task SaveChangeAsyncWithCommit();
        Task<List<category>> GetCategoryBySupplierIdAsync(string supplier_id);

    }
}

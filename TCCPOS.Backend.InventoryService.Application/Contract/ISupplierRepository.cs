using TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ISupplierRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<SupplierResult>> GetSupplier();
    }
}

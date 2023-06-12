namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IInventoryRepository
    {
        Task SaveChangeAsyncWithCommit();

    }
}

using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IUserRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<user?> GetUserByUserID(string userID);
    }
}

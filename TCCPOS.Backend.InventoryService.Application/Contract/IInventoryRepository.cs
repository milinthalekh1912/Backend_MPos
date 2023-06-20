using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IInventoryRepository
    {
       IMerchantGroupRepository MerchantGroup { get; }
        ITargetRepository Target { get; }
        IOrderRepository Order { get; }
        IDeliveryDetailRepository DeliveryDetail { get; }
        ISupplierRepository Supplier { get; }
        ISkuRepository Sku { get; }
        IPromotionRepository Promotion { get; }
        IMerchantRepository Merchant { get; }
        ICategoriesRepository Categories { get; }
        IAddressRepository Address { get; }
        IUserRepository User { get; }
    }
}

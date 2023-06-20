using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public InventoryRepository(InventoryContext context)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        IMerchantGroupRepository _merchantgroup = null!;
        public IMerchantGroupRepository MerchantGroup => _merchantgroup ??= new MerchantGroupRepository(_context, _dtnow);

        ITargetRepository _target = null!;
        public ITargetRepository Target => _target ??= new TargetRepository(_context, _dtnow);

        IOrderRepository _order = null!;
        public IOrderRepository Order => _order ??= new OrderRepository(_context, _dtnow);

        IDeliveryDetailRepository _deliveryDetail = null!;
        public IDeliveryDetailRepository DeliveryDetail => _deliveryDetail ??= new DeliveryDetailRepository(_context, _dtnow);
        
        ISupplierRepository _supplier = null!;
        public ISupplierRepository Supplier => _supplier ??= new SupplierRepository(_context, _dtnow);
        
        ISkuRepository _sku = null!;
        public ISkuRepository Sku => _sku ??= new SkuRepository(_context, _dtnow);
        
        IPromotionRepository _promotion = null!;
        public IPromotionRepository Promotion => _promotion ??= new PromotionRepository(_context, _dtnow);

        IMerchantRepository _merchant = null!;
        public IMerchantRepository Merchant => _merchant ??= new MerchantRepository(_context, _dtnow);

        ICategoriesRepository _categories = null!;
        public ICategoriesRepository Categories => _categories ??= new CategoriesRepository(_context, _dtnow);
        
        IAddressRepository _address = null!;
        public IAddressRepository Address => _address ??= new AddressRepository(_context, _dtnow);
        
        IUserRepository _user = null!;
        public IUserRepository User => _user ??= new UserRepository(_context, _dtnow);

        IPriceTierRepository _pricetier = null!;
        public IPriceTierRepository PriceTier => _pricetier ??= new PriceTierRepository(_context, _dtnow);
    }
}





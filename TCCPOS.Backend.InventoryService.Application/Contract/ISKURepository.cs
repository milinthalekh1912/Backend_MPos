using MediatR;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductRecommend.Query.GetProductRecommend;
using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;
using TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier;
using TCCPOS.Backend.InventoryService.Entities;
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;
using TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ISkuRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<List<sku>> getAllSkuAsync();
        public Task<List<ProductRecommendResult>> GetSkuRecommend(string supplier_id);
        public Task<List<SkuByKeywordResult>> GetSkuByKeyword(string? keyword);
        public Task<List<GetProductByCatResult>> GetSkuBycateID(String categoryId, String supplierId, string shopId);
       
    }
}

using MediatR;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;
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

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IOrderRepository
    {
        Task SaveChangeAsyncWithCommit();
        public Task<order> createOrderAsync(string order_id, string userId, string shopId, string supplierId, string addressId, string coupon);
        public Task<List<orderdetail>> createOrderItemAsync(string order_id, List<OrderItemRequest> orderItems, string userId, string shopId);
        public Task<deliverydetail> createOrderDeliveryDetailAsync(string order_id, string userId);
        public Task<List<GetAllOrdersResult>> getAllOrderAsync(string supplierId, string userId, string shopId);
        public Task<GetOrderByIdResult> getOrderByIdAsync(string order_id, string shopId);
        public Task<GetOrderByIdResult> getOrderByIdBackOfficeAsync(string order_id);
        public Task<ConfirmLogisticResult> ConfirmLogistic(string shop_id, string user_id, string order_id, string delivery_detail_id);
        public Task<order> ConfirmOrderByOrderId(ConfirmOrderCommand command);
        public Task<order> UpdateOrderStatusByOrderID(string orderID);

    }
}

using MediatR;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface IInventoryRepository
    {
        public Task<order> createOrderAsync(string userId, string shopId, string supplierId, string addressId, string coupon);

        public Task<List<orderdetail>> createOrderItemAsync(string order_id, List<OrderItemRequest> orderItems, string userId);

        public Task<deliverydetail> createOrderDeliveryDetailAsync(string order_id, string userId);

        public Task<List<GetAllOrdersResult>> getAllOrderAsync(string supplierId, string userId, string shopId);

        public Task<List<deliverydetail>> getDeliveryDetailsByOrderIdAsync(string order_id);

        public Task<GetOrderByIdResult> getOrderByIdAsync(string order_id, string shopId);

        public Task<shopgroup> createNewGroupAsync(string shopGroupId, string shopGroupName, string userId);

        public Task<List<shop>> addShopToGroupAsync(List<string> shopId);

        public Task<List<GetAllShopGroupResult>> getAllShopGroupAsync();

        public Task<GetShopGroupByIdResult> getShopGroupById(string shopGroupId);

        public Task<int> deleteShopGroupById(string shopGroupId, string userId);

        public Task<UpdateGroupResult> updateGroupById(string shopGroupId, string userId, string shopGroupName, List<string> shopList);

        public Task<List<GetAllShopResult>> getAllShopAsync();

        public Task updateNameByGroupId(string groupName, string shopGroupId, string userId);



    }
}

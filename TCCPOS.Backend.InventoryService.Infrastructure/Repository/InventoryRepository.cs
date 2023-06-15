using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShop;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;
using TCCPOS.Backend.InventoryService.Entities;

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

        public async Task<order> createOrderAsync(string order_id, string userId, string shopId, string supplierId, string addressId, string coupon)
        {
            var newOrder = new order
            {
                order_id = order_id,
                user_id = userId,
                shop_id = shopId,
                supplier_id = supplierId,
                address_id = addressId,
                coupon_id = coupon,
                is_read = false,
                payment_status = 1,
                created_by = userId,
                updated_by = userId,
                created_date = _dtnow,
                updated_date = _dtnow,
            };

            await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }

        public async Task<List<sku>> getAllSkuAsync()
        {
            var all_sku = await _context.sku.AsNoTracking().Where(e => true).ToListAsync();
            return all_sku;
        }

        public async Task<List<orderdetail>> createOrderItemAsync(string order_id, List<OrderItemRequest> orderItems, string userId)
        {

            List<orderdetail> newOrderItems = orderItems.Select(e =>
            {
                return new orderdetail
                {
                    order_item_id = Guid.NewGuid().ToString(),
                    sku_id = e.sku_id,
                    order_id = order_id,
                    amount = e.amount,
                    price = 0,
                    created_by = userId,
                    updated_by = userId,
                    created_date = _dtnow,
                    updated_date = _dtnow,
                };
            }).ToList();

            await _context.AddRangeAsync(newOrderItems);
            await _context.SaveChangesAsync();

            return newOrderItems;
        }

        public async Task<deliverydetail> createOrderDeliveryDetailAsync(string order_id, string userId)
        {
            List<deliverydetail> deliveryDetails = new List<deliverydetail>();

            deliveryDetails.Add(new deliverydetail
            {
                delivery_detail_id = Guid.NewGuid().ToString(),
                order_id = order_id,
                cost = 0,
                estimate_date = _dtnow,
                due_date = _dtnow,
                is_express = false,
            });


            deliveryDetails.Add(new deliverydetail
            {
                delivery_detail_id = Guid.NewGuid().ToString(),
                order_id = order_id,
                cost = 0,
                estimate_date = _dtnow,
                due_date = _dtnow,
                is_express = true,
            });

            await _context.AddRangeAsync(deliveryDetails);
            await _context.SaveChangesAsync();
            return new deliverydetail();
        }

        public async Task<List<GetAllOrdersResult>> getAllOrderAsync(string supplierId, string userId, string shopId)
        {
            var query = from order in _context.order
                        where order.shop_id == shopId && order.supplier_id == supplierId
                        join orderItem in (
                            from sku in _context.sku
                            join oi in _context.orderdetail on sku.sku_id equals oi.sku_id
                            select new { SKU = sku, OrderItem = oi }
                        ) on order.order_id equals orderItem.OrderItem.order_id
                        select new { Order = order, SKU = orderItem.SKU, OrderItem = orderItem.OrderItem };


            var results = await query.AsNoTracking().ToListAsync();

            var orders = results.GroupBy(r => r.Order)
                    .Select(group => new GetAllOrdersResult
                    {
                        order_id = group.Key.order_id,
                        is_read = group.Key.is_read ?? false,
                        user_id = group.Key.user_id,
                        shop_id = group.Key.shop_id,
                        shop_name = group.Key.supplier_id,
                        order_amount = group.Sum(r => r.OrderItem.amount) ?? 0,
                        order_items = group.Select(r => new OrderItemResult
                        {
                            order_item_id = r.OrderItem.order_item_id,
                            sku_id = r.OrderItem.sku_id,
                            amount = r.OrderItem.amount ?? 0,
                            price = r.OrderItem.price,
                            sku_title = r.SKU.title,
                            sku_alias_title = r.SKU.alias_title,
                            sku_barcode = r.SKU.barcode,
                            image_url = r.SKU.image_url,
                            sku_category_id = r.SKU.category_id,
                        }).ToList()
                    })
                    .ToList();
            return orders;
        }

        public async Task<List<deliverydetail>> getDeliveryDetailsByOrderIdAsync(string order_id)
        {
            var deliverysDetail = await _context.deliverydetail.AsNoTracking().Where(e => e.order_id == order_id).ToListAsync();
            return deliverysDetail;
        }

        public async Task<GetOrderByIdResult> getOrderByIdAsync(string order_id, string shopId)
        {
            var query = from order in _context.order
                        where order.order_id == order_id && order.shop_id == shopId
                        join orderItem in (
                            from sku in _context.sku
                            join oi in _context.orderdetail on sku.sku_id equals oi.sku_id
                            select new { SKU = sku, OrderItem = oi }
                        ) on order.order_id equals orderItem.OrderItem.order_id
                        select new { Order = order, SKU = orderItem.SKU, OrderItem = orderItem.OrderItem };

            var results = await query.AsNoTracking().ToListAsync();

            var orderResult = results.GroupBy(r => r.Order)
                    .Select(group => new GetOrderByIdResult
                    {
                        order_id = group.Key.order_id,
                        is_read = true,
                        user_id = group.Key.user_id,
                        shop_id = group.Key.shop_id,
                        shop_name = group.Key.supplier_id,
                        address_id = group.Key.address_id,
                        order_amount = group.Sum(r => r.OrderItem.amount) ?? 0,
                        order_items = group.Select(r => new OrderItemResult
                        {
                            order_item_id = r.OrderItem.order_item_id,
                            sku_id = r.OrderItem.sku_id,
                            amount = r.OrderItem.amount ?? 0,
                            price = r.OrderItem.price,
                            sku_title = r.SKU.title,
                            sku_alias_title = r.SKU.alias_title,
                            sku_barcode = r.SKU.barcode,
                            image_url = r.SKU.image_url,
                            sku_category_id = r.SKU.category_id,
                        }).ToList()
                    })
                    .FirstOrDefault();


            var updateReadStatus = await _context.order.FirstOrDefaultAsync(e => e.order_id == order_id);

            updateReadStatus.is_read = true;
            await _context.SaveChangesAsync();


            return orderResult;
        }

        public async Task<shopgroup> createNewGroupAsync(string shopGroupId, string shopGroupName, string userId)
        {
            var request = new shopgroup
            {
                shop_group_id = shopGroupId,
                group_name = shopGroupName,
                created_by = userId,
                created_date = _dtnow,
                updated_by = userId,
                updated_date = _dtnow
            };

            await _context.shopgroup.AddAsync(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<List<shop>> addShopToGroupAsync(List<string> shopId)
        {
            var newId = Guid.NewGuid().ToString();

            var results = await _context.shop.Where(e => shopId.Contains(e.shop_id)).ToListAsync();

            results.ForEach(shop =>
            {
                if (shop.shop_group_id != null)
                {
                    throw InventoryServiceException.IE012;
                }
                shop.shop_group_id = newId;
            });

            await _context.SaveChangesAsync();

            return results;
        }

        public async Task<List<GetAllShopGroupResult>> getAllShopGroupAsync()
        {
            var queryable = from sg in _context.shopgroup
                            join s in _context.shop on sg.shop_group_id equals s.shop_group_id
                            group s by new { sg.shop_group_id, sg.group_name } into g
                            select new
                            {
                                shopGroupId = g.Key.shop_group_id,
                                shopGroupName = g.Key.group_name,
                                totalShop = g.Count()
                            };

            var resultList = await queryable.AsNoTracking().ToListAsync();

            return resultList.Select(e =>
            {
                return new GetAllShopGroupResult
                {
                    shopAmount = e.totalShop,
                    shopGroupId = e.shopGroupId,
                    shopGroupName = e.shopGroupName,
                };
            }).ToList();
        }

        public async Task<GetShopGroupByIdResult> getShopGroupById(string shopGroupId)
        {
            var shopGroup = await _context.shopgroup.AsNoTracking().FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            var shops = await _context.shop.AsNoTracking().Where(e => e.shop_group_id == shopGroupId).ToListAsync();

            if (shopGroup == null)
            {
                throw InventoryServiceException.IE013;
            }

            return new GetShopGroupByIdResult
            {
                shop_group_id = shopGroup.shop_group_id,
                group_name = shopGroup.group_name,
                shopList = shops.Select(e =>
                {
                    return new ShopResult
                    {
                        shopId = e.shop_id,
                        shopName = e.shop_name
                    };
                }).ToList()
            };
        }

        public async Task<int> deleteShopGroupById(string shopGroupId, string userId)
        {
            var users = await _context.shop.Where(e => e.shop_group_id == shopGroupId).ToListAsync();

            users.ForEach(e =>
            {
                e.shop_group_id = null;
                e.updated_date = _dtnow;
                e.updated_by = userId;
            });

            var shopGroup = _context.Remove(_context.shopgroup.Single(e => e.shop_group_id == shopGroupId));
            _context.rewardtarget.RemoveRange(_context.rewardtarget.Where(e => e.shop_group_id == shopGroupId));

            return await _context.SaveChangesAsync();
        }


        public async Task<UpdateGroupResult> updateGroupById(string shopGroupId, string userId, string shopGroupName, List<string> shopList)
        {
            var shopGroup = await _context.shopgroup.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            if (shopGroup == null)
            {
                throw InventoryServiceException.IE013;
            }
            shopGroup.group_name = shopGroupName;
            shopGroup.updated_date = _dtnow;
            shopGroup.updated_by = userId;

            var users = await _context.shop.Where(e => e.shop_group_id == shopGroupId).ToListAsync();
            users.ForEach(e =>
            {
                e.shop_group_id = null;
            });

            var results = await _context.shop.Where(e => shopList.Contains(e.shop_id)).ToListAsync();

            results.ForEach(shop =>
            {
                if (shop.shop_group_id != null)
                {
                    throw InventoryServiceException.IE012;
                }
                shop.shop_group_id = shopGroupId;
            });

            await _context.SaveChangesAsync();

            return new UpdateGroupResult
            {
                shopgroup = shopGroup,
                shops = results,
            };
        }

        public async Task<List<GetAllShopResult>> getAllShopAsync()
        {
            var queryable = from s in _context.shop
                            join sg in _context.shopgroup on s.shop_group_id equals sg.shop_group_id into shopGroupJoin
                            from sg in shopGroupJoin.DefaultIfEmpty()
                            select new
                            {
                                s.shop_id,
                                s.shop_name,
                                s.shop_group_id,
                                GroupName = sg != null ? sg.group_name : null
                            };

            var results = await queryable.ToListAsync();

            return results.Select(e =>
            {
                return new GetAllShopResult
                {
                    shopId = e.shop_id,
                    shopGroupId = e.shop_group_id,
                    shopName = e.shop_name,
                    shopGroupName = e.GroupName
                };
            }).ToList();
        }

        public async Task updateNameByGroupId(string groupName, string shopGroupId, string userId)
        {
            var shopGroup = await _context.shopgroup.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            shopGroup.group_name = groupName;
            shopGroup.updated_by = userId;
            shopGroup.updated_date = _dtnow;

            await _context.SaveChangesAsync();
        }
    }
}





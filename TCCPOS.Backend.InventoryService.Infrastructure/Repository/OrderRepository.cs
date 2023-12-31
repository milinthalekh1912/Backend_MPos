﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;
using TCCPOS.Backend.InventoryService.Entities;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrderByMerchantId;
using MediatR;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;

        public OrderRepository(InventoryContext context, DateTime _dtnow)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        public async Task SaveChangeAsyncWithCommit()
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                _context.Database.SetCommandTimeout(120);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<orderdetail>> createOrderItemBackoffice(string order_id, List<CreateOrderBackofficeItemRequest> orderItems, string userId, string merchantId)
        {

            var merchantDetail = await getShopProfileAsync(merchantId);

            List<orderdetail> newOrderItems = orderItems.Select(e =>
            {
                return new orderdetail
                {
                    order_item_id = Guid.NewGuid().ToString(),
                    sku_id = e.sku_id,
                    order_id = order_id,
                    amount = e.amount,
                    price = e.price,
                    created_by = userId,
                    updated_by = userId,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now,
                };
            }).ToList();

            await _context.AddRangeAsync(newOrderItems);
            await _context.SaveChangesAsync();

            return newOrderItems;
        }

        public async Task<order> createOrderBackOffice(string order_id, CreateOrderBackOfficeCommand command)
        {
            var supplier = await _context.supplier.FirstOrDefaultAsync(e => e.supplier_id == command.SupplierID);
            if (supplier == null)
            {
                throw InventoryServiceException.IE017;
            }
            var supplierDocNo = supplier.DocNo;
            var newStringSupplierNo = (int.Parse(supplierDocNo) + 1).ToString();
            supplier.DocNo = newStringSupplierNo.PadLeft(5, '0');

            var sum = command.Order_Items.Sum(x => x.amount * x.price);

            var newOrder = new order
            {
                order_id = order_id,
                order_no = $"PO{_dtnow.Month}{_dtnow.Year}/{supplierDocNo}",
                order_type = 1,
                total = sum,
                total_discount = 0.00,
                user_id = command.UserID,
                merchant_id = command.MerchantID,
                supplier_id = command.SupplierID,
                address_id = command.AddressID,
                coupon_id = command.CouponID,
                is_read = false,
                order_status = 1,
                payment_status = 1,
                created_by = command.UserID,
                updated_by = command.UserID,
                created_date = DateTime.Now,
                updated_date = DateTime.Now,
            };

            await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }
        public async Task<List<orderdetail>> createOrderItemBackOffice(string order_id, List<CreateOrderBackofficeItemRequest> orderItems, string userId, string merchantId)
        {

            var shopDetail = await getShopProfileAsync(merchantId);

            List<orderdetail> newOrderItems = orderItems.Select(e =>
            {
                return new orderdetail
                {
                    order_item_id = Guid.NewGuid().ToString(),
                    sku_id = e.sku_id,
                    title = e.title,
                    order_id = order_id,
                    amount = e.amount,
                    price = e.price,
                    created_by = userId,
                    updated_by = userId,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now,
                };
            }).ToList();

            await _context.AddRangeAsync(newOrderItems);
            await _context.SaveChangesAsync();

            return newOrderItems;
        }


        public async Task<order> createOrderAsync(string order_id, string userId, string shopId, string supplierId, string addressId, string coupon)
        {
            var supplier = await _context.supplier.FirstOrDefaultAsync(e => e.supplier_id == supplierId);
            if (supplier == null)
            {
                throw InventoryServiceException.IE017;
            }

            var supplierDocNo = supplier.DocNo;
            var newStringSupplierNo = (int.Parse(supplierDocNo) + 1).ToString();
            supplier.DocNo = newStringSupplierNo.PadLeft(5, '0');
            var newOrder = new order
            {
                order_id = order_id,
                order_no = $"PO{_dtnow.Month}{_dtnow.Year}/{supplierDocNo}",
                order_type = 2,
                total = 0.00,
                total_discount= 0.00,
                user_id = userId,
                merchant_id = shopId,
                supplier_id = supplierId,
                address_id = addressId,
                coupon_id = coupon,
                is_read = false,
                order_status = 1,
                payment_status = 1,
                created_by = userId,
                updated_by = userId,
                created_date = DateTime.Now,
                updated_date = DateTime.Now,
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

        public async Task<merchant> getShopProfileAsync(string shopId)
        {
            var shop = await _context.merchant.AsNoTracking().FirstOrDefaultAsync(e => e.merchant_id == shopId);
            return shop;
        }

        public async Task<List<orderdetail>> createOrderItemAsync(string order_id, List<OrderItemRequest> orderItems, string userId, string shopId)
        {

            var shopDetail = await getShopProfileAsync(shopId);

            var skuPriceList = await _context.pricetier.Where(e => e.price_tier_group_id == shopDetail.price_tier_id).ToListAsync();
            List<orderdetail> newOrderItems = orderItems.Select(e =>
            {
                return new orderdetail
                {
                    order_item_id = Guid.NewGuid().ToString(),
                    sku_id = e.sku_id,
                    title = "",
                    order_id = order_id,
                    amount = e.amount,
                    price = skuPriceList?.FirstOrDefault(x => x.sku_id == e.sku_id)?.price ?? 0,
                    created_by = userId,
                    updated_by = userId,
                    created_date = DateTime.Now,
                    updated_date = DateTime.Now,
                };
            }).ToList();

            await _context.AddRangeAsync(newOrderItems);
            await _context.SaveChangesAsync();

            return newOrderItems;
        }

        /*public async Task<deliverydetail> createOrderDeliveryDetailAsync(string order_id, string userId)
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
        }*/

       /* public async Task<deliverydetail> CreateOrderDeliveryDetailBackOffice(string order_id, string userId)
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
        }*/

        public async Task<List<GetAllOrdersResult>> getAllOrderAsync(string supplierId, string userId, string shopId)
        {
            var orders = new List<GetAllOrdersResult>();
            List<order> order_context = await _context.order.Where(x => x.supplier_id == supplierId).ToListAsync(); ;
            /*if (shopId == "ADMIN")
            {
                order_context = await _context.order.Where(x => x.supplier_id == supplierId).ToListAsync();
            }
            else
            {
                order_context = await _context.order.Where(x => x.supplier_id == supplierId && x.merchant_id == shopId).ToListAsync();
            }*/

            foreach (var ord in order_context)
            {
                GetAllOrdersResult getOrder = new GetAllOrdersResult();

                var custommer = await _context.merchant.FirstOrDefaultAsync(x => x.merchant_id == ord.merchant_id);
                var sku_list = await _context.sku.Where(x => x.supplier_id == supplierId).ToListAsync();

                getOrder.order_id = ord.order_id;
                getOrder.order_no = ord.order_no;
                getOrder.is_read = ord.is_read ?? true;
                getOrder.order_status = ord.order_status ?? 1;
                getOrder.shop_id = ord.merchant_id;
                getOrder.user_id = ord.user_id;
                getOrder.supplier_name = ord.supplier_id;
                getOrder.customer_name = custommer.merchant_name ?? "";
                getOrder.address_id = ord.address_id;
                getOrder.created_date = ord.created_date ?? _dtnow;
                getOrder.order_items = new List<OrderItemResult>();
                var count_amount_item = 0;
                var item_context = await _context.orderdetail.Where(x => x.order_id == ord.order_id).ToListAsync();
                foreach (var item in item_context)
                {
                    OrderItemResult item_res = new OrderItemResult();
                    var sku = sku_list.FirstOrDefault(x => x.sku_id == item.sku_id);
                    item_res.order_item_id = item.order_item_id;
                    item_res.sku_id = item.sku_id;
                    item_res.amount = item.amount ?? 0;
                    item_res.price = item.price ?? 0;
                    item_res.sku_title = sku.title ?? "";
                    item_res.sku_alias_title = sku!.alias_title ?? sku.title!;
                    item_res.sku_barcode = sku.sku_id;
                    item_res.image_url = sku.image_url ?? "";
                    item_res.sku_category_id = sku.category_id;
                    count_amount_item = count_amount_item + item_res.amount;

                    getOrder.order_items.Add(item_res);
                }
                getOrder.order_amount = count_amount_item;
                orders.Add(getOrder);
            }

            return orders;
        }

        public async Task<List<order>> getAllOrder(string supplierId, string userId, string shopId)
        {
            List<order> order_context = await _context.order.Where(x => x.supplier_id == supplierId).ToListAsync();
            /*if (shopId == "ADMIN")
            {
                order_context = await _context.order.Where(x => x.supplier_id == supplierId).ToListAsync();
            }
            else
            {
                order_context = await _context.order.Where(x => x.supplier_id == supplierId && x.merchant_id == shopId).ToListAsync();
            }
*/
            return order_context;
            
        }

        public async Task<GetAllOrderByMerchantIdResult> getAllOrderByMerchantID(string merchantID)
        {
            var result = new GetAllOrderByMerchantIdResult();

            var order_join = from order in _context.order
                             where order.merchant_id == merchantID
                             join orderItem in _context.orderdetail
                             on order.order_id equals orderItem.order_id
                             select new
                             {
                                 Order = order,
                                 OrderItem = orderItem,
                             };
            var sku_join = from order in order_join
                           join sku in _context.sku
                           on order.OrderItem.sku_id equals sku.sku_id
                           where order.Order.supplier_id == sku.supplier_id
                           select new
                           {
                               Order = order.Order,
                               OrderItem = order.OrderItem,
                               SKU = sku,
                           };

            /*var query = from order in _context.order
                        where order.merchant_id == merchantID
                        join orderItem in (
                            from sku in _context.sku
                            join oi in _context.orderdetail on sku.sku_id equals oi.sku_id
                            select new { SKU = sku, OrderItem = oi }
                        ) on order.orderId equals orderItem.OrderItem.orderId
                        select new { Order = order, SKU = orderItem.SKU, OrderItem = orderItem.OrderItem };*/

            var merchant = await _context.merchant.FirstOrDefaultAsync(x => x.merchant_id == merchantID);

            var results = await sku_join.AsNoTracking().ToListAsync();

            var orderGroup = results.GroupBy(r => r.Order.order_id)
                    .Select(group => new GetAllOrderByMerchantIdItemResult
                    {
                        order_id = group.Key,
                        order_no = group.First().Order.order_no,
                        is_read = true,
                        user_id = group.First().Order.user_id,
                        shop_id = group.First().Order.merchant_id,
                        supplier_name = group.First().Order.supplier_id,
                        customer_name = merchant.merchant_name,
                        order_status = group.First().Order.order_status ?? 0,
                        created_date = group.First().Order.created_date ?? _dtnow,
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
                    }).ToList();
            //var results = await query.AsNoTracking().ToListAsync();
            foreach (var order in orderGroup)
            {
                /*GetAllOrderByMerchantIdItemResult item = new GetAllOrderByMerchantIdItemResult();
                item.orderId = order.Order.orderId;
                item.order_no = order.Order.order_no;
                item.total = 0.00;
                item.total_discount = 0.00;
                item.is_read = (bool)order.Order.is_read;
                item.order_status = (int)order.Order.order_status;
                item.userId = order.Order.userId;
                item.merchant_id = order.Order.merchant_id;
                item.supplierId = order.Order.supplierId;
                item.customer_name = merchant.merchant_name;*/
                result.item.Add(order);

            }

            return result;
        }

        public async Task<List<orderdetail>> GetOrderDetailByOrderId(string order_id)
        {
            var order_detail = await _context.orderdetail.Where(x => x.order_id == order_id).ToListAsync();
            return order_detail;
        }


        public async Task<GetOrderByIdResult> getOrderByIdAsync(string order_id, string shopId)
        {
            var query = from order in _context.order
                        where order.order_id == order_id && order.merchant_id == shopId
                        join orderItem in (
                            from sku in _context.sku
                            join oi in _context.orderdetail on sku.sku_id equals oi.sku_id
                            select new { SKU = sku, OrderItem = oi }
                        ) on order.order_id equals orderItem.OrderItem.order_id
                        select new { Order = order, SKU = orderItem.SKU, OrderItem = orderItem.OrderItem };

            
            var results = await query.AsNoTracking().ToListAsync();

            var shopList = await _context.merchant.Where(e => true).ToListAsync();
            
            var address = await _context.merchantaddress.FirstOrDefaultAsync(x => x.address_id == results.First().Order.address_id);

            AddressResult addressResult = new AddressResult();
            addressResult.address_title = address.address_title;
            addressResult.address1 = address.address1;
            addressResult.address2 = address.address2;
            addressResult.address3 = address.address3;
            addressResult.zipcode = address.zipcode;

            var orderResult = results.GroupBy(r => r.Order.order_id)
                    .Select(group => new GetOrderByIdResult
                    {
                        order_id = group.Key,
                        is_read = true,
                        user_id = group.First().Order.user_id,
                        shop_id = group.First().Order.merchant_id,
                        supplier_name = group.First().Order.supplier_id,
                        customer_name = shopList.FirstOrDefault(e => e.merchant_id == group.First().Order.merchant_id).merchant_name,
                        address = addressResult,
                        order_status = group.First().Order.order_status ?? 0,
                        created_date = group.First().Order.created_date ?? _dtnow,
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

        public async Task<GetOrderByIdResult> getOrderByIdBackOfficeAsync(string order_id)
        {
            var query = from order in _context.order
                        where order.order_id == order_id
                        join orderItem in (
                            from sku in _context.sku
                            join oi in _context.orderdetail on sku.sku_id equals oi.sku_id
                            select new { SKU = sku, OrderItem = oi }
                        ) on order.order_id equals orderItem.OrderItem.order_id
                        select new { Order = order, SKU = orderItem.SKU, OrderItem = orderItem.OrderItem };

            var results = await query.AsNoTracking().ToListAsync();
            var add_id = results.First().Order.address_id;

            var shopList = await _context.merchant.Where(e => true).ToListAsync();
            var address = await _context.merchantaddress.FirstOrDefaultAsync(x => x.address_id == add_id);

            AddressResult addressResult = new AddressResult();
            addressResult.address_title = address.address_title;
            addressResult.address1 = address.address1;
            addressResult.address2 = address.address2;
            addressResult.address3 = address.address3;

            var orderResult = results.GroupBy(r => r.Order.order_id)
                    .Select(group => new GetOrderByIdResult
                    {
                        order_id = group.Key,
                        is_read = true,
                        user_id = group.First().Order.user_id,
                        shop_id = group.First().Order.merchant_id,
                        supplier_name = group.First().Order.supplier_id,
                        customer_name = shopList.FirstOrDefault(e => e.merchant_id == group.First().Order.merchant_id).merchant_name,
                        address = addressResult,
                        order_status = group.First().Order.order_status ?? 0,
                        created_date = group.First().Order.created_date ?? _dtnow,
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

        public async Task<order> ConfirmOrderByOrderId(ConfirmOrderCommand command)
        {
            var order_obj = await _context.order.FirstOrDefaultAsync(x => x.order_id == command.orderId);

            if (order_obj == null) throw InventoryServiceException.IE018;

            if (order_obj.order_status != 1) throw InventoryServiceException.IE019;
            order_obj.is_read = false;
            order_obj.order_status = 2;
            order_obj.updated_date = DateTime.Now;
            order_obj.updated_by = command.userId;

            deliverydetail deli_Details = new deliverydetail
            {
                delivery_detail_id = Guid.NewGuid().ToString(),
                order_id = command.orderId,
                cost = 0,
                estimate_date = command.esimate_date,
                due_date = command.due_date,
                is_express = false,
                note = command.note,
            };

            await _context.AddRangeAsync(deli_Details);
            await _context.SaveChangesAsync();
            return order_obj;
        }

        public async Task<order> ConfirmOrderByBackOffice(ConfirmOrderCommand command)
        {
            var order_obj = await _context.order.FirstOrDefaultAsync(x => x.order_id == command.orderId);

            if (order_obj == null) throw InventoryServiceException.IE018;

            order_obj.order_status = 3;
            order_obj.updated_date = DateTime.Now;
            order_obj.updated_by = command.userId;
            order_obj.is_read = false;
            deliverydetail deli_Details = new deliverydetail
            {
                delivery_detail_id = Guid.NewGuid().ToString(),
                order_id = command.orderId,
                cost = 0,
                estimate_date = command.esimate_date,
                due_date = command.due_date,
                is_express = false,
                note = command.note,
            };

            order_obj.delivery_detail_id = deli_Details.delivery_detail_id;
            await _context.AddRangeAsync(deli_Details);
            await _context.SaveChangesAsync();
            return order_obj;
        }

        public async Task<order> UpdateOrderStatusByOrderID(string orderID)
        {
            var order_obj = await _context.order.FirstOrDefaultAsync(x => x.order_id == orderID);
            if (order_obj == null) throw InventoryServiceException.IE018;
            order_obj.order_status = order_obj.order_status + 1;
            order_obj.is_read=false;
            await _context.SaveChangesAsync();
            return order_obj;
        }

        public async Task<ConfirmLogisticResult> ConfirmLogistic(string shop_id, string user_id, string order_id, string delivery_detail_id)
        {
            var order = await _context.order.Where(e => e.order_id == order_id).FirstOrDefaultAsync();
            if (order == null)
            {
                throw InventoryServiceException.IE001;
            }
            order.delivery_detail_id = delivery_detail_id;
            order.updated_date = DateTime.Now;
            order.updated_by = user_id;
            order.order_status = 3;
            order.is_read = false;
            var updatedelivery = new ConfirmLogisticResult
            {
                delivery_detail_id = delivery_detail_id,
                user_id = user_id,
                shop_id = shop_id,
                order_id = order_id,
            };

            await _context.SaveChangesAsync();

            return updatedelivery;
        }
        
    }
}





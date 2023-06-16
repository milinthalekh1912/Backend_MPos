using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
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
using TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress;
using TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic;
using TCCPOS.Backend.InventoryService.Entities;
using TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByCat.Query.GetProductByCat;
using TCCPOS.Backend.InventoryService.Application.Feature.Shop.Query.GetAllShop;
using System.Collections.Generic;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;

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

        public Task SaveChangeAsyncWithCommit()
        {
            return null;
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
                user_id = userId,
                shop_id = shopId,
                supplier_id = supplierId,
                address_id = addressId,
                coupon_id = coupon,
                is_read = false,
                order_status = 1,
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

        public async Task<shop> getShopProfileAsync(string shopId)
        {
            var shop = await _context.shop.AsNoTracking().FirstOrDefaultAsync(e => e.shop_id == shopId);
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
                    order_id = order_id,
                    amount = e.amount,
                    price = skuPriceList?.FirstOrDefault(x => x.sku_id == e.sku_id)?.price ?? 0,
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
            var orders = new List<GetAllOrdersResult>();
            List<order> order_context;
            if (shopId == "ADMIN")
            {
                order_context = await _context.order.Where(x => x.supplier_id == supplierId).ToListAsync();
            }
            else
            {
                order_context = await _context.order.Where(x => x.supplier_id == supplierId && x.shop_id == shopId).ToListAsync();
            }

            foreach (var ord in order_context)
            {
                GetAllOrdersResult getOrder = new GetAllOrdersResult();

                var custommer = await _context.shop.FirstOrDefaultAsync(x => x.shop_id == ord.shop_id);
                var sku_list = await _context.sku.Where(x => x.supplier_id == supplierId).ToListAsync();

                getOrder.order_id = ord.order_id;
                getOrder.is_read = ord.is_read ?? true;
                getOrder.order_status = ord.order_status ?? 1;
                getOrder.shop_id = ord.shop_id;
                getOrder.user_id = ord.user_id;
                getOrder.supplier_name = ord.supplier_id;
                getOrder.customer_name = custommer.shop_name ?? "";
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

            var shopList = await _context.shop.Where(e => true).ToListAsync();

            var orderResult = results.GroupBy(r => r.Order.order_id)
                    .Select(group => new GetOrderByIdResult
                    {
                        order_id = group.Key,
                        is_read = true,
                        user_id = group.First().Order.user_id,
                        shop_id = group.First().Order.shop_id,
                        supplier_name = group.First().Order.supplier_id,
                        customer_name = shopList.FirstOrDefault(e => e.shop_id == group.First().Order.shop_id).shop_name,
                        address_id = group.First().Order.address_id,
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

            var shopList = await _context.shop.Where(e => true).ToListAsync();

            var orderResult = results.GroupBy(r => r.Order.order_id)
                    .Select(group => new GetOrderByIdResult
                    {
                        order_id = group.Key,
                        is_read = true,
                        user_id = group.First().Order.user_id,
                        shop_id = group.First().Order.shop_id,
                        supplier_name = group.First().Order.supplier_id,
                        customer_name = shopList.FirstOrDefault(e => e.shop_id == group.First().Order.shop_id).shop_name,
                        address_id = group.First().Order.address_id,
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


        public async Task<List<deliverydetail>> getDeliveryDetailsByOrderIdAsync(string order_id)
        {
            var deliverysDetail = await _context.deliverydetail.AsNoTracking().Where(e => e.order_id == order_id).ToListAsync();
            return deliverysDetail;
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


        public async Task<List<SupplierResult>> GetSupplier()
        {
            var suppliers = await _context.supplier.Where(x => true).ToListAsync(); // Retrieve all suppliers

            List<SupplierResult> result = new List<SupplierResult>();

            foreach (var supplier in suppliers)
            {
                SupplierResult obj = new SupplierResult();
                obj.shopId = supplier.supplier_id;
                obj.shopTitle = supplier.supplier_name;
                obj.shopImageUrl = supplier.supplier_image;
                obj.isPriceShow = supplier.is_show_price ?? false;
                obj.isStockShow = supplier.is_show_stock ?? false;

                result.Add(obj);
            }


            return result;
        }

        public async Task<List<ProductRecommendResult>> GetProductRecommend(string supplier_id)
        {
            var skus = await _context.sku.Join(_context.pricetier, sku => sku.sku_id, pricetier => pricetier.sku_id,
                    (sku, pricetier) => new { SKU = sku, PriceTier = pricetier })
                    .Where(x => x.SKU.supplier_id == supplier_id)
                    .ToListAsync();

            List<ProductRecommendResult> result = new List<ProductRecommendResult>();

            foreach (var SKU in skus)
            {
                ProductRecommendResult obj = new ProductRecommendResult();
                obj.title = SKU.SKU.title;
                obj.aliasTitle = SKU.SKU.alias_title;
                obj.sku = SKU.SKU.sku_id;
                obj.barcode = SKU.SKU.barcode;
                obj.imageUrl = SKU.SKU.image_url;
                obj.categoryId = SKU.SKU.category_id;
                obj.price = SKU.PriceTier.price;

                bool isPurchaseBefore = await _context.order.AnyAsync(item => item.created_by == SKU.SKU.created_by);
                obj.isPurchaseBefore = isPurchaseBefore;

                result.Add(obj);
            }

            return result;
        }


        public async Task<List<ProductByKeywordResult>> GetProductByKeyword(string? keyword)
        {
            var query = _context.sku.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.alias_title == keyword || x.title == keyword || x.barcode == keyword);
            }

            var products = await query
                .Join(_context.pricetier, sku => sku.sku_id, pricetier => pricetier.sku_id,
                    (sku, pricetier) => new { SKU = sku, PriceTier = pricetier })
                .ToListAsync();



            var result = new List<ProductByKeywordResult>();

            foreach (var product in products)
            {
                ProductByKeywordResult obj = new ProductByKeywordResult();

                obj.title = product.SKU.title;
                obj.aliasTitle = product.SKU.alias_title;
                obj.sku = product.SKU.sku_id;
                obj.barcode = product.SKU.barcode;
                obj.imageUrl = product.SKU.image_url;
                obj.categoryId = product.SKU.category_id;
                obj.price = product.PriceTier.price;

                result.Add(obj);
            }

            return result;
        }

        public async Task<List<PromotionResult>> GetPromotion()
        {
            var promotions = await _context.promotion.Where(x => true).ToListAsync();
            List<PromotionResult> result = new List<PromotionResult>();

            foreach (var promotion in promotions)
            {
                PromotionResult obj = new PromotionResult();
                obj.promotionId = promotion.promotion_id;
                obj.promotionType = promotion.promotion_type;
                obj.promotionDescription = new List<PromotionResult.PromotionDetails>();

                var promotionConditions = promotion.conditions?.Split(',').ToList();


                foreach (var condition in promotionConditions)
                {
                    var skus = await _context.sku.Where(y => true).ToListAsync();

                    if (skus != null)
                    {
                        PromotionResult.PromotionDetails promotionDetail = new PromotionResult.PromotionDetails
                        {
                            condition = condition,
                            groupSkuA = new List<PromotionResult.PromotionDetails.GroupSku>()
                        };

                        foreach (var sku in skus)
                        {
                            PromotionResult.PromotionDetails.GroupSku groupSku = new PromotionResult.PromotionDetails.GroupSku
                            {
                                title = sku.title,
                                sku = sku.sku_id,
                                barcode = sku.barcode,
                                imageUrl = sku.image_url,
                                aliasTitle = sku.alias_title
                            };

                            promotionDetail.groupSkuA.Add(groupSku);
                        }

                        obj.promotionDescription.Add(promotionDetail);
                    }
                }


                result.Add(obj);
            }

            return result;
        }

        public async Task<List<AllAddressResult>> GetAllAddress(string shopId)
        {
            var shopAddress = await _context.shopaddress.AsNoTracking().Where(e => e.shop_id == shopId).ToListAsync();
            List<AllAddressResult> results = new List<AllAddressResult>();
            if (shopAddress == null || !shopAddress.Any())
            {
                throw InventoryServiceException.IE001;
            }
            foreach (var item in shopAddress)
            {
                AllAddressResult obj = new AllAddressResult();
                obj.addressId = item.address_id;
                obj.shopTitle = item.shop_title;
                obj.address1 = item.address1;
                obj.address2 = item.address2;
                obj.address3 = item.address3;
                obj.zipcode = item.zipcode;
                obj.phoneNumber = item.phone_number;
                results.Add(obj);
            }
            return results;
        }

        public async Task<ConfirmLogisticResult> ConfirmLogistic(string shop_id, string user_id, string order_id, string delivery_detail_id)
        {
            var order = await _context.order.Where(e => e.order_id == order_id).FirstOrDefaultAsync();
            if (order == null)
            {
                throw InventoryServiceException.IE001;
            }
            order.delivery_detail_id = delivery_detail_id;
            order.updated_date = _dtnow;
            order.updated_by = user_id;
            order.order_status = 3;

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


        public async Task<List<CategoryResult>> GetCategoryBySupplierIdAsync(string supplier_id)
        {
            var categories = await _context.category.Where(e => e.supplier_id == supplier_id).ToListAsync();
            List<CategoryResult> results = new List<CategoryResult>();


            if (categories == null || !categories.Any()) { throw InventoryServiceException.IE001; }

            foreach (var category in categories)
            {
                CategoryResult obj = new CategoryResult();
                obj.CategoryId = category.category_id;
                obj.CategoryName = category.category_name;

                results.Add(obj);

            }
            return results;


        }


        public async Task<GetAddressByIdResult> GetAddressById(string? address_id)
        {
            var address = await _context.shopaddress.FirstOrDefaultAsync(elem => elem.address_id == address_id);

            var result = new GetAddressByIdResult()
            {
                addressId = address?.address_id,
                address1 = address?.address1,
                address2 = address?.address2,
                address3 = address?.address3,
                zipcode = address?.zipcode
            };

            return result;
        }

        public async Task<List<GetProductByCatResult>> GetProductBycat(string categoryId, string supplierId, string shopId)
        {
            var productinfo = await _context.sku.AsNoTracking().Where(x => x.category_id == categoryId && x.supplier_id == supplierId).ToListAsync();
            List<GetProductByCatResult> results = new List<GetProductByCatResult>();
            if (productinfo == null || !productinfo.Any())
            {
                throw InventoryServiceException.IE001;
            }

            foreach (var item in productinfo)
            {
                GetProductByCatResult obj = new GetProductByCatResult();
                obj.title = item.title;
                obj.aliasTitle = item.alias_title;
                obj.sku = item.sku_id;
                obj.barcode = item.barcode;
                obj.imageUrl = item.image_url;
                obj.categoryId = item.category_id;
                results.Add(obj);
            }
            return results;
        }

        public async Task<order> ConfirmOrderByOrderId(ConfirmOrderCommand command)
        {
            var order_obj = await _context.order.FirstOrDefaultAsync(x => x.order_id == command.orderId);

            if (order_obj == null) throw InventoryServiceException.IE018;

            if (order_obj.order_status != 1) throw InventoryServiceException.IE019;

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

        public async Task<GetAllShopAddressResult> getAllShopWithAddressAsync()
        {
            {
                var queryable = from s in _context.shop
                                join sg in _context.shopaddress on s.shop_id equals sg.shop_id into shopAddressJoin
                                from sg in shopAddressJoin.DefaultIfEmpty()
                                select new
                                {
                                    s.shop_id,
                                    s.shop_name,
                                    sg.address_id,
                                };

                var results = await queryable.ToListAsync();

                return new GetAllShopAddressResult
                {
                    shopAddress = results.Select(e =>
                    {
                        return new ShopWithAddressResult
                        {
                            shop_id = e.shop_id,
                            shop_name = e.shop_name,
                            shop_address_id = e.address_id

                        };
                    }).ToList()
                };
            }
        }
        public async Task<user?> GetUserByUserID(string userID)
        {
            var user = await _context.user.FirstOrDefaultAsync(x => x.id == userID);
            return user;
        }

        public async Task<order> UpdateOrderStatusByOrderID(string orderID)
        {
            var order_obj = await _context.order.FirstOrDefaultAsync(x => x.order_id == orderID);
            if (order_obj == null) throw InventoryServiceException.IE018;
            order_obj.order_status = order_obj.order_status + 1;
            await _context.SaveChangesAsync();
            return order_obj;
        }
    }
}





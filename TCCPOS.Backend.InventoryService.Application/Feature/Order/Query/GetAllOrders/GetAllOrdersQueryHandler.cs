using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersResult>>
    {
        private readonly ILogger<GetAllOrdersQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllOrdersQueryHandler(ILogger<GetAllOrdersQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<List<GetAllOrdersResult>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            List<GetAllOrdersResult> res= new List<GetAllOrdersResult>();
            var order_context = await _repo.Order.getAllOrder(request.supplierId, request.userId, request.shopId);
            var custommer = await _repo.Merchant.getMerchantById(request.shopId);
            var sku_list = await _repo.Sku.getAllSkuAsync(request.supplierId);


            foreach (var ord in order_context)
            {
                GetAllOrdersResult getOrder = new GetAllOrdersResult();
                
                getOrder.order_id = ord.order_id;
                getOrder.order_no = ord.order_no;
                getOrder.is_read = ord.is_read ?? true;
                getOrder.order_status = ord.order_status ?? 1;
                getOrder.shop_id = ord.merchant_id;
                getOrder.user_id = ord.user_id;
                getOrder.supplier_name = ord.supplier_id;
                getOrder.customer_name = custommer.merchant_name ?? "";
                getOrder.address_id = ord.address_id;
                getOrder.created_date = ord.created_date ?? DateTime.Now;
                getOrder.order_items = new List<OrderItemResult>();
                var count_amount_item = 0;
                var item_context = await _repo.Order.GetOrderDetailByOrderId(ord.order_id);
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
                res.Add(getOrder);
            }
            res = res.OrderBy(x => x.created_date).ToList();
            return res;

        }
    }
}

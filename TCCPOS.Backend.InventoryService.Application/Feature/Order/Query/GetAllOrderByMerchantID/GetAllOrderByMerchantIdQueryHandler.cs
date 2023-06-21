using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrderByMerchantId;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById
{
    public class GetAllOrderByMerchantIdQueryHandler : IRequestHandler<GetAllOrderByMerchantIdQuery, GetAllOrderByMerchantIdResult>
    {
        private readonly ILogger<GetAllOrderByMerchantIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllOrderByMerchantIdQueryHandler(ILogger<GetAllOrderByMerchantIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetAllOrderByMerchantIdResult> Handle(GetAllOrderByMerchantIdQuery request, CancellationToken cancellationToken)
        {
            var res = new GetAllOrderByMerchantIdResult();
            var ordere_list = await _repo.Order.getAllOrderByMerchantID(request.MerchantId);
            /*
            var merchant = await _repo.Merchant.getMerchantById(request.MerchantId);
            foreach( var order in ordere_list )
            {
                var order_detail = await _repo.Order.GetOrderDetailByOrderId(order.order_id);
                GetAllOrderByMerchantIdItemResult item = new GetAllOrderByMerchantIdItemResult();
                item.order_id = order.order_id;
                item.order_no = order.order_no;
                item.total = 0.00;
                item.total_discount = 0.00;
                item.is_read = (bool)order.is_read;
                item.order_status = (int)order.order_status;
                item.user_id = order.user_id;
                item.shop_id = order.merchant_id;
                item.supplier_id = order.supplier_id;
                item.customer_name = merchant.merchant_name;
                foreach (var itemDetail in order_detail)
                {
                    OrderItemResult orderItem = new OrderItemResult();
                    orderItem.sku_id = itemDetail.sku_id;
                    orderItem.sku_barcode = itemDetail.sku_id;
                    orderItem.sku_title = itemDetail.title;
                    //orderItem.amount = itemDetail.amount;
                    orderItem.price = itemDetail.price;
                    orderItem.sku_alias_title = item.
                }
                /*
             

            }*/
            return ordere_list;
        }
    }
}

/*
   "order_id": "22465450-095c-4cd6-8a5d-cfd55a566912",
    "order_no": null,
    "total": 0,
    "total_discount": 0,
    "is_read": false,
    "order_status": 1,
    "user_id": "4d819af2-801b-4e28-94d5-c2656424b607",
    "shop_id": "ed22d3b5-f175-4be0-a12c-5bbd3003174d",
    "supplier_name": "changhouse",
    "customer_name": "ร้าน test1",
    "order_amount": 1,
    "address_id": "9c6dda58-5e8e-434d-8eda-0b95d5467df1",
    "created_date": "0001-01-01T00:00:00",
    "order_items": [
      {
        "order_item_id": "7e730810-c73c-4db8-b5bf-fe7c5e4bafa0",
        "sku_id": "000004",
        "amount": 1,
        "price": 0,
        "sku_title": "ค่ามัดจำลังเอสโคล่า 330+ขวด",
        "sku_alias_title": "ค่ามัดจำลังเอสโคล่า 330+ขวด",
        "sku_barcode": "000004",
        "image_url": "",
        "sku_category_id": null
 */

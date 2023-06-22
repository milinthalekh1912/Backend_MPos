using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice
{
    public class CreateOrderBackOfficeCommand : IRequest<CreateOrderBackOfficeResult>
    {
        public string UserID { get; set; }
        public string MerchantID { get; set; }
        public string SupplierID { get; set; }
        public string? CouponID { get; set; } = null!;
        public double? Total { get; set; } = null!;
        public double? TotalDiscount { get; set; } = null!;
        public DateTime EsimateDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsBoardcase { get; set; }
        public string? Note { get; set; } = null;
        public string AddressID { get; set; }
        public List<CreateOrderBackofficeItemRequest> Order_Items { get; set; }
        public CreateOrderBackOfficeCommand(string userId,CreateOrderBackOfficeRequest request)
        {
            UserID= userId;
            MerchantID= request.merchant_id;
            SupplierID= request.supplier_id;
            CouponID= request.coupon_id;
            AddressID= request.address_id;
            Order_Items = request.order_items;
            EsimateDate= request.esimate_date;
            DueDate= request.due_date;
            IsBoardcase= request.is_boardcase;
            Note= request.note;
        }

    }
}

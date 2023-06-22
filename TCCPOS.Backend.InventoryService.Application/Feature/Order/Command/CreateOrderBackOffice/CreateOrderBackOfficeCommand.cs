using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice
{
    public class CreateOrderBackOfficeCommand : IRequest<CreateOrderBackOfficeResult>
    {
        public string UserID { get; set; }
        public string MerchantID { get; set; }
        public string SupplierID { get; set; }
        public string? CouponID { get; set; } = null!;
        [Required]
        public string AddressID { get; set; }
        public List<OrderItemRequest> Order_Items { get; set; }
        public CreateOrderBackOfficeCommand(string userId,string merchantId,string supplierId,string? couponId,string addressId, List<OrderItemRequest>  orderItem)
        {

        }

    }
}

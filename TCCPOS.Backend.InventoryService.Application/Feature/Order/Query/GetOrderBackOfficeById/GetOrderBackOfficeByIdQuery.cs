using MediatR;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderBackOfficeById
{
    public class GetOrderBackOfficeByIdQuery : IRequest<GetOrderByIdResult>
    {
        public string OrderId { get; set; }

        public string SupplierID { get; set; }

        public GetOrderBackOfficeByIdQuery(string supplierId,string orderId)
        {
            OrderId = orderId;
            SupplierID = supplierId;
        }
    }
}

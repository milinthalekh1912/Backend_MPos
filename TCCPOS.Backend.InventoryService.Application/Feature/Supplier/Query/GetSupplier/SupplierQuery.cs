using MediatR;


namespace TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier
{
    public class GetSupplierQuery : IRequest<List<SupplierResult>>
    {
    }
}

using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat
{
    public class GetProductByCatQuery : IRequest<List<GetProductByCatResult>>
    {
        public string supplierId { get; set; }
        public string categoryId { get; set; }
        public string shopId { get; set; }
    }
}

using MediatR;
using System.ComponentModel.DataAnnotations;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder
{
    public class CreateTargetCommand : IRequest<CreateTargetResult>
    {

        public string shopGroupId { get; set; }

        public string skuId { get; set; }

        public int target { get; set; }

        public string reward { get; set; }

        public string resetDate { get; set; }

        public string userId { get; set; }
    }
}
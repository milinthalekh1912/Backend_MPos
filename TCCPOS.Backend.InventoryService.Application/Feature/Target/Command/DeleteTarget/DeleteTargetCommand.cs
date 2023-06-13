using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.DeleteTarget
{
    public class DeleteTargetCommand : IRequest<DeleteTargetResult>
    {
        public string skuId { get; set; }
        public string shopGroupId { get; set; }
    }
}

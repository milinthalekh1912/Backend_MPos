using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget
{
    public class UpdateTargetCommand : IRequest<UpdateTargetResult>
    {
        public string targetId { get; set; }
        public string shopGroupId { get; set; }
        public string skuId { get; set; }
        public int target { get; set; }

        public string reward { get; set; }
        public string resetDate { get; set; }
        public string userId { get; set; }


    }
}

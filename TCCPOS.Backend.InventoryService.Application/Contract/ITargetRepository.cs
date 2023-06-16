using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Contract
{
    public interface ITargetRepository
    {
        public Task<CreateTargetResult> createSkuTargetAsync(string shopGroupId, string skuId, int target, string reward, string reset_date, string userId);

        public Task<UpdateTargetResult> updateSkuTargetAsync(string rewardId, string shopGroupId, string skuId, int target, string reward, string reset_date, string userId);

        public Task deleteTargetById(string shopGroupId, string skuId);

        public Task<List<TargetResult>> GetTarget();


    }
}

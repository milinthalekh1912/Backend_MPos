using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class TargetRepository : ITargetRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;

        public TargetRepository(InventoryContext context)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        public async Task<CreateTargetResult> createSkuTargetAsync(string shopGroupId, string skuId, int target, string reward, string reset_date, string userId)
        {
            var shopgroup = await _context.shopgroup.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId);
            if (shopgroup == null)
            {
                throw InventoryServiceException.IE013;
            }

            var sku = await _context.rewardtarget.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId && e.sku_id == skuId);
            if (sku != null)
            {
                throw InventoryServiceException.IE014;
            }

            var newSkuTarget = new rewardtarget
            {
                reward_id = Guid.NewGuid().ToString(),
                shop_group_id = shopGroupId,
                target = target,
                sku_id = skuId,
                reward = reward,
                start_date = DateTime.Parse(reset_date),
                end_date = DateTime.Parse(reset_date),
                created_date = _dtnow,
                updated_date = _dtnow,
                updated_by = userId,
                created_by = userId,
            };

            await _context.rewardtarget.AddAsync(newSkuTarget);
            await _context.SaveChangesAsync();

            return new CreateTargetResult
            {
                targetId = newSkuTarget.reward_id,
                skuId = newSkuTarget.sku_id,
                target = newSkuTarget.target ?? 0,
                shopGroupId = newSkuTarget.shop_group_id,
                resetDate = newSkuTarget.end_date.ToString(),
                reward = newSkuTarget.reward,
            };
        }

        public async Task<UpdateTargetResult> updateSkuTargetAsync(string rewardId, string shopGroupId, string skuId, int target, string reward, string reset_date, string userId)
        {
            var rewardTarget = await _context.rewardtarget.FirstOrDefaultAsync(e => e.reward_id == rewardId);
            if (rewardTarget == null)
            {
                throw InventoryServiceException.IE015;
            }

            rewardTarget.target = target;
            rewardTarget.sku_id = skuId;
            rewardTarget.reward = reward;
            rewardTarget.start_date = DateTime.Parse(reset_date);
            rewardTarget.end_date = DateTime.Parse(reset_date);
            rewardTarget.updated_by = userId;
            rewardTarget.updated_date = _dtnow;

            await _context.SaveChangesAsync();

            return new UpdateTargetResult
            {
                targetId = rewardTarget.reward_id,
                skuId = rewardTarget.sku_id,
                target = rewardTarget.target ?? 0,
                shopGroupId = rewardTarget.shop_group_id,
                resetDate = rewardTarget.end_date.ToString(),
                reward = rewardTarget.reward,
            };
        }

        public async Task deleteTargetById(string shopGroupId, string skuId)
        {
            var rewardTarget = await _context.rewardtarget.FirstOrDefaultAsync(e => e.shop_group_id == shopGroupId && e.sku_id == skuId);
            if (rewardTarget == null)
            {
                throw InventoryServiceException.IE015;
            }

            _context.rewardtarget.Remove(rewardTarget);

            await _context.SaveChangesAsync();
        }


    }
}

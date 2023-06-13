using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget
{
    public class UpdateTargetCommandHandler : IRequestHandler<UpdateTargetCommand, UpdateTargetResult>
    {
        private readonly ILogger<CreateTargetCommandHandler> _logger;
        ITargetRepository _repo;
        IConfiguration _config;

        public UpdateTargetCommandHandler(ILogger<CreateTargetCommandHandler> logger, ITargetRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<UpdateTargetResult> Handle(UpdateTargetCommand request, CancellationToken cancellationToken)
        {
            var res = await _repo.updateSkuTargetAsync(request.targetId, request.shopGroupId, request.skuId, request.target, request.reward, request.resetDate, request.userId);
            return res;
        }
    }
}

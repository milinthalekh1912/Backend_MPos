using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.CreateTarget
{
    public class CreateTargetCommandHandler : IRequestHandler<CreateTargetCommand, CreateTargetResult>
    {
        private readonly ILogger<CreateTargetCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public CreateTargetCommandHandler(ILogger<CreateTargetCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<CreateTargetResult> Handle(CreateTargetCommand request, CancellationToken cancellationToken)
        {
            var res = await _repo.Target.createSkuTargetAsync(request.shopGroupId, request.skuId, request.target, request.reward, request.resetDate, request.userId);
            return res;
        }

    }
}

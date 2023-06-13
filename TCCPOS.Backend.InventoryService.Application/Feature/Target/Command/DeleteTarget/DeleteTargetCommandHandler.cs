using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.DeleteShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.DeleteTarget
{
    public class DeleteTargetCommandHandler : IRequestHandler<DeleteTargetCommand, DeleteTargetResult>
    {
        private readonly ILogger<DeleteTargetCommandHandler> _logger;
        ITargetRepository _repo;
        IConfiguration _config;

        public DeleteTargetCommandHandler(ILogger<DeleteTargetCommandHandler> logger, ITargetRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<DeleteTargetResult> Handle(DeleteTargetCommand request, CancellationToken cancellationToken)
        {
            await _repo.deleteTargetById(request.shopGroupId, request.skuId);
            return new DeleteTargetResult
            {
                message = "delete completed"
            };
        }
    }
}

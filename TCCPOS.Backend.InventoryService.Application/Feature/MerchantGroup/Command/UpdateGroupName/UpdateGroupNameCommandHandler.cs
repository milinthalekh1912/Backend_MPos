using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupName
{
    public class UpdateGroupNameCommandHandler : IRequestHandler<UpdateGroupNameCommand, UpdateMerchantGroupNameResult>
    {
        private readonly ILogger<UpdateGroupNameCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public UpdateGroupNameCommandHandler(ILogger<UpdateGroupNameCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }


        public async Task<UpdateMerchantGroupNameResult> Handle(UpdateGroupNameCommand request, CancellationToken cancellationToken)
        {
            await _repo.MerchantGroup.updateNameByGroupId(request.shopGroupName, request.shopGroupId, request.userId);
            return new UpdateMerchantGroupNameResult
            {
                message = "update complelte"
            };
        }
    }
}

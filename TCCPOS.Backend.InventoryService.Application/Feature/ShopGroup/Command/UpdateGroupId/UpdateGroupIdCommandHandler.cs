using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId
{
    public class UpdateGroupIdCommandHandler : IRequestHandler<UpdateGroupIdCommand, UpdateGroupResult>
    {
        private readonly ILogger<UpdateGroupIdCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public UpdateGroupIdCommandHandler(ILogger<UpdateGroupIdCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<UpdateGroupResult> Handle(UpdateGroupIdCommand request, CancellationToken cancellationToken)
        {
            var results = await _repo.updateGroupById(request.shopGroupId, request.userId, request.shopGroupName, request.shopList);
            return results;
        }


    }
}

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.DeleteShopGroup
{
    public class DeleteShopGroupCommandHandler : IRequestHandler<DeleteShopGroupCommand, DeleteShopGroupResult>
    {
        private readonly ILogger<DeleteShopGroupCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public DeleteShopGroupCommandHandler(ILogger<DeleteShopGroupCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<DeleteShopGroupResult> Handle(DeleteShopGroupCommand request, CancellationToken cancellationToken)
        {
            await _repo.ShopGroup.deleteShopGroupById(request.shopGroupId,request.userId);
            return new DeleteShopGroupResult
            {
                message = "delete completed"
            };
        }
    }
}

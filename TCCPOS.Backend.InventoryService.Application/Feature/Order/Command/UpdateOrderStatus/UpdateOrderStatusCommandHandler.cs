using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.UpdateOrderStatus
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, UpdateOrderStatusResult>
    {
        private readonly ILogger<UpdateOrderStatusCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public UpdateOrderStatusCommandHandler(ILogger<UpdateOrderStatusCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<UpdateOrderStatusResult> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var res = new UpdateOrderStatusResult();
            var obj = await _repo.UpdateOrderStatusByOrderID(command.orderId);
            return res;
        }

    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic
{
    public class ConfirmLogisticCommandHandler : IRequestHandler<ConfirmLogisticCommand, ConfirmLogisticResult>
    {
        private readonly ILogger<ConfirmLogisticCommandHandler> _logger;
        IInventoryRepository _repo;

        public ConfirmLogisticCommandHandler(ILogger<ConfirmLogisticCommandHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<ConfirmLogisticResult> Handle(ConfirmLogisticCommand request, CancellationToken cancellationToken)
        {
            var selectdelivery = await _repo.Order.ConfirmLogistic(request.shop_id, request.user_id, request.order_id, request.delivery_detail_id);
            return new ConfirmLogisticResult
            {
                shop_id = selectdelivery.shop_id,
                user_id = selectdelivery.user_id,
                order_id = selectdelivery.order_id,
                delivery_detail_id = selectdelivery.delivery_detail_id,
            };
        }
    }
}


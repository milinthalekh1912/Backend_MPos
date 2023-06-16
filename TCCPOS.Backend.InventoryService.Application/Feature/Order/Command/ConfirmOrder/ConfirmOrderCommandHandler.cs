using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, ConfirmOrderResult>
    {
        private readonly ILogger<ConfirmOrderCommandHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public ConfirmOrderCommandHandler(ILogger<ConfirmOrderCommandHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<ConfirmOrderResult> Handle(ConfirmOrderCommand command, CancellationToken cancellationToken)
        {
            var res = new ConfirmOrderResult();
            var com = await _repo.ConfirmOrderByOrderId(command);
            return res;
        }


    }
}

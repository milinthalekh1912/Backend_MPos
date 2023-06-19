using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            var com = await _repo.Order.ConfirmOrderByOrderId(command);

            if (command.is_boardcase)
            {
                var user = await _repo.User.GetUserByUserID(command.userId);
                if (user != null && user.line_sub_Id != null)
                {
                    var chanelToken = "8MGabTsr+8vXmZt39lv/CvuoTLi56qiS/hH+EW4npP++z0eQ9axdV/XimTLWZ1oNkJpvg5IqO0gY3ITT7+K0yC6MxOXkslBkgI8eEi5N+CGCzxLs7839NS74w9+0t+4Eu6Lgiu9x+q+JR2OLQ3QvBgdB04t89/1O/w1cDnyilFU=";
                    var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", chanelToken);

                    MessageModel mss = new MessageModel
                    {
                        type = "text",
                        text = $"Order no . {command.orderId} Confirmed"
                    };


                    PushMessageModel pushMessageModel = new PushMessageModel();
                    pushMessageModel.to = user.line_sub_Id;
                    pushMessageModel.messages.Add(mss);

                    var content = JsonConvert.SerializeObject(pushMessageModel);
                    var requestContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://api.line.me/v2/bot/message/push", requestContent);
                    response.EnsureSuccessStatusCode();

                }

            }
            return res;
        }


    }
}

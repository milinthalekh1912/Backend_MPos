using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest<ConfirmOrderResult>
    {
        public string userId { get; set; }
        public string shopId { get; set; }
        public string orderId { get; set; }
        public string note { get; set; } = null;
        public DateTime esimate_date { get; set; }
        public DateTime due_date { get; set; }
        public bool is_boardcase { get; set; }

        public ConfirmOrderCommand(string UserID,string ShopID,ConfirmOrderRequest command)
        {
            userId = UserID;
            shopId = ShopID;
            orderId= command.orderId;
            note= command.note;
            esimate_date= command.esimate_date;
            due_date= command.due_date;
            is_boardcase= command.is_boardcase;
        }
    }
}

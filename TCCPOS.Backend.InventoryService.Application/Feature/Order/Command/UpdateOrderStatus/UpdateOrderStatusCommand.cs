using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest<UpdateOrderStatusResult>
    {
        public string userId { get; set; }
        public string shopId { get; set; }
        public string orderId { get; set; }
        //public int order_status { get; set; }

        public UpdateOrderStatusCommand(string UserID,string ShopID,UpdateOrderStatusRequest command)
        {
            userId = UserID;
            shopId = ShopID;
            orderId= command.orderId;
            //order_status = command.order_status;
        }
    }
}

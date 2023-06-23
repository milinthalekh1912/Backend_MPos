using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderBackOfficeById
{
    public class AddressResult
    {
        public string address_title { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string zipcode { get; set; }
    }
}

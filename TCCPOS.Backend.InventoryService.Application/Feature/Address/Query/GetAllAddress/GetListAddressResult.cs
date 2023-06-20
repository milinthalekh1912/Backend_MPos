using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress
{
    public class GetListAddressResult
    {
        public List<AddressResult> items { get; set; } = new List<AddressResult>();
    }
}

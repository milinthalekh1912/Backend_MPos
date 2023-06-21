using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress
{
    public class GetListAddressResult
    {
        public List<AddressDetailResult> items { get; set; } = new List<AddressDetailResult>();
    }
}

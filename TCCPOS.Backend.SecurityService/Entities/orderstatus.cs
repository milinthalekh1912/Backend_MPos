using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class orderstatus
    {
        public int OrderStatusID { get; set; }
        public string? StatusDescription { get; set; }
    }
}

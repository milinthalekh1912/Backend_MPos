using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class paymentstatus
    {
        public int payment_status_id { get; set; }
        public string? status_description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLoginByPass
{
    public class LineLoginByPassRequest
    {
        [Required]
        public string subId { get; set; }
    }
}

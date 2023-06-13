using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLogin
{
    public class LineValidateTokenResult
    {
        public string sub { get; set; }
        public string name { get; set; }
        public string picture { get; set; }

    }
}

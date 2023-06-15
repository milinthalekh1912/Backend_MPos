using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.SecurityService.Entities
{
    public partial class currentversion
    {
        public sbyte MajorVersion { get; set; }
        public sbyte? MinorVersion { get; set; }
        public sbyte? BuildVersion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.Business.StringInfo
{
    public class JwtInfo
    {
        public string ISSUER { get; set; }
        public string AUDIENCE { get; set; }
        public string SECURITYKEY { get; set; }
        public double EXPIRES { get; set; }
    }
}

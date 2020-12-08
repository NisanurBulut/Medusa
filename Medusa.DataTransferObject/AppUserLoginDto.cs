using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.DataTransferObject.Concrete
{
    public class AppUserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

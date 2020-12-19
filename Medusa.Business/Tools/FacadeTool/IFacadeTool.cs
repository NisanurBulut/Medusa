using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.Business.Tools
{
    public interface IFacadeTool
    {
        public IMemoryCache MemoryCache { get; set; }
        public ICustomLog CustomLog { get; set; }

    }
}

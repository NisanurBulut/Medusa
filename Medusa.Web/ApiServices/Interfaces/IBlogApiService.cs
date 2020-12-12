using Medusa.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.WebUI.ApiServices.Interfaces
{
    public interface IBlogApiService
    {
       Task<List<BlogListModel>> GetAllAsync();
    }
}

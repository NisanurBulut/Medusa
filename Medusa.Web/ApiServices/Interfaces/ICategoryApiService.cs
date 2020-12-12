using System.Collections.Generic;
using System.Threading.Tasks;
using Medusa.WebUI.Models;
namespace Medusa.WebUI.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<List<CategoryListModel>> GetAllAsync();
    }
}

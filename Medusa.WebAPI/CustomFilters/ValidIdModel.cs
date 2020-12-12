using Medusa.Business;
using Medusa.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.WebAPI.CustomFilters
{
    public class ValidIdModel<tEntity> : IActionFilter where tEntity : class, ITable, new()
    {
        private readonly IGenericService<tEntity> _genericService;
        public ValidIdModel(IGenericService<tEntity> genericService)
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(a => a.Key == "id").FirstOrDefault();
            var id = int.Parse(dictionary.Value.ToString());
            var entity = _genericService.FindByIdAsync(id).Result;
            if (entity == null) context.Result = new NotFoundObjectResult($"{id} değerine sahip nesne bulunamadı ");
        }
    }
}

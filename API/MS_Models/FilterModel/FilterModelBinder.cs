using Microsoft.AspNetCore.Mvc.ModelBinding;
using MS_Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.FilterModel
{
    public class FilterModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var jsonString = bindingContext.ActionContext.HttpContext.Request.Query["Filter"];
            FilterViewModel result = JsonConvert.DeserializeObject<FilterViewModel>(jsonString)!;

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
    public class FilterModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(FilterViewModel))
                return new FilterModelBinder();

            return null!;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WSProductos1001.API.Filters;

public class GlobalValidationFilterAttribute : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(context.ActionArguments.Any(a => a.Value == null))
        {
            context.Result = new BadRequestObjectResult("Null values are not allowed");
        }
        if(context.ModelState.IsValid == false)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
            return;
        }
        
        await next();
    }
}
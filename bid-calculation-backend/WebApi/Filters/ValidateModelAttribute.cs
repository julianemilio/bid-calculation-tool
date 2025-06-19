using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(new
            {
                Title = "Validation failed",
                Errors = context.ModelState
                    .ToDictionary(
                        k => k.Key,
                        v => v.Value.Errors.Select(e => e.ErrorMessage))
            });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class RequireProducesResponseTypeFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var endpoint = context.HttpContext.GetEndpoint();

        var hasProducesResponseType = endpoint?.Metadata.GetMetadata<ProducesResponseTypeAttribute>() != null;

        if (!hasProducesResponseType)
        {
            context.Result = new BadRequestObjectResult("Each action must have at least one ProducesResponseType attribute for documentation.");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
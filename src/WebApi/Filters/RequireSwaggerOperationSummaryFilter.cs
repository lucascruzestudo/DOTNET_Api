using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Swashbuckle.AspNetCore.Annotations;

public class RequireSwaggerOperationSummaryFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint();

            var swaggerOperation = endpoint?.Metadata.GetMetadata<SwaggerOperationAttribute>();

            if (swaggerOperation == null || string.IsNullOrWhiteSpace(swaggerOperation.Summary))
            {
                context.Result = new BadRequestObjectResult("Each action must have a SwaggerOperation attribute with a non-empty Summary.");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
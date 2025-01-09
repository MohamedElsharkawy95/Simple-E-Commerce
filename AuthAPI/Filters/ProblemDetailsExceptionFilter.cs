using AuthAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthAPI.Filters;

public class ProblemDetailsExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is BaseApplicationException exception)
        {
            context.Result = new ObjectResult(exception.Problem)
            {
                StatusCode = exception.Problem.Status
            };
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}

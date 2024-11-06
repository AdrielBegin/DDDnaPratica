using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrortHandlingFiltersAtttibute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        context.Result = new ObjectResult(new { error = "An erro occurred while processing your request" }){
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }

}

using CodeChallenge.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CodeChallenge.Api.Base
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid) 
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                var message = context.ModelState.Values.Where(Va => Va.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage).ToList();
                APIResponse result = new APIResponse()
                {
                    Error = true,
                    Message = "There were validations Errors",
                    Data = message
                };
                context.Result = new JsonResult(result)
                {
                    StatusCode = 400,
                };
            }
            else
            {
                //It continues if the validation was ok
                await next();
            }

        }
    }
}

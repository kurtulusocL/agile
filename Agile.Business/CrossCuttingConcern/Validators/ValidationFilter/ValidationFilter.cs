﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Agile.Business.CrossCuttingConcern.Validators.ValidationFilter
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                     .Where(i => i.Value.Errors.Any())
                     .ToDictionary(i => i.Key, i => i.Value.Errors.Select(i => i.ErrorMessage)).ToArray();
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}
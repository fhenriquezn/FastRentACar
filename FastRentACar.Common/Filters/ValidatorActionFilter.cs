using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace FastRentACar.Common.Filters
{
    public class ValidatorActionFilter : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public ValidatorActionFilter(int Order = 0)
        {
            this.Order = Order;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                string ErrorMessage = null;
                foreach (ModelStateEntry modelValue in context.ModelState.Values)
                {
                    foreach (ModelError modelError in modelValue.Errors)
                    {
                        ErrorMessage = modelError.ErrorMessage;
                        break;
                    }
                    if (!(string.IsNullOrEmpty(ErrorMessage)))
                        break;
                }
                if (!(string.IsNullOrEmpty(ErrorMessage)))
                {
                    context.Result = new BadRequestObjectResult(ErrorMessage);
                    return;
                }

            }
            await next();
        }
    }
}

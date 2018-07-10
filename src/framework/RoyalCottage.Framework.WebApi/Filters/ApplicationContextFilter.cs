using Microsoft.AspNetCore.Mvc.Filters;

namespace RoyalCottage.Framework.WebApi.Filters
{
    public class ApplicationContextFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as BaseController;
            controller?.SetContext();
        }
    }
}

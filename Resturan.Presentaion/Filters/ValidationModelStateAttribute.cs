using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Resturan.Presentation.Filters
{
    public class ValidationModelStateAttribute:Attribute,IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            
            if (context.HandlerArguments.Count !=0)
            {
                var argument = context.HandlerArguments.ToList();
                var param = argument.FirstOrDefault(x=>x.Key.Contains("id"));
                if (param.Key == "id" &&param.Value == null)
                    context.Result = new BadRequestResult();
            }
            if (!context.ModelState.IsValid)
            {
                
                var page = context.HandlerInstance as PageModel;
                    context.Result = page!.Page();
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

    }

}

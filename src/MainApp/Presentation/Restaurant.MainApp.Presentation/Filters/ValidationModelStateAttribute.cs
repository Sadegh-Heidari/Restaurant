using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.MainApp.Presentation.Filters
{
    public class ValidationModelStateAttribute:Attribute,IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            
            if (!context.ModelState.IsValid)
            {

                var page = context.HandlerInstance as PageModel;

                context.Result =  page.Page();
            }
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
           
        }

    }

}

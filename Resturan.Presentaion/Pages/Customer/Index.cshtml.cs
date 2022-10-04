using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Query;
using Resturan.Application.Query.DTO;

namespace Resturan.Presentation.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private IApplicationQuery _applicationQuery { get; }
        public ILookup<string,CustomerDto> Customer { get; set; }
        public IndexModel(IApplicationQuery applicationQuery)
        {
            _applicationQuery = applicationQuery;
            
        }

        public async Task OnGet()
        {
            var result = await _applicationQuery.GetCustomerQuery();
            Customer = result.ToLookup(x=>x.CategoryName);
        }
    }
}

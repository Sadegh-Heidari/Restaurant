using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Query;
using Resturan.Application.Query.DTO;
using Resturan.Infrastructure.Tools.Tools;
using Resturan.Presentation.Tools;

namespace Resturan.Presentation.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private IApplicationQuery _applicationQuery { get; }
        public IEnumerable<IGrouping<string?,CustomerDto?>>? Customer { get; set; }
        private CartShopCount _cartShopCount { get; }
        public IndexModel(IApplicationQuery applicationQuery, CartShopCount cartShopCount)
        {
            _applicationQuery = applicationQuery;
            _cartShopCount = cartShopCount;
        }

        public async Task OnGet()
        {
           
            TempData["cart"]= await _cartShopCount.CountCartCooki(HttpContext);
        var result = await _applicationQuery.GetMenuItemQueryAsync();
            Customer = result?.GroupBy(x=>x.CategoryName);
        }
    }
}

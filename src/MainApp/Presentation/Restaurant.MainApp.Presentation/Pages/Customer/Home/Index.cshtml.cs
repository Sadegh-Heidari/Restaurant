using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Query;
using Restaurant.MainApp.Core.Application.Query.DTO;
using Restaurant.MainApp.Presentation.Tools;

namespace Restaurant.MainApp.Presentation.Pages.Customer.Home
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

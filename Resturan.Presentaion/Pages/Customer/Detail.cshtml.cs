using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Query;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Pages.Customer.ViewModel;

namespace Resturan.Presentation.Pages.Customer
{
    [Authorize]
    [ValidationModelState]
    public class DetailModel : PageModel
    {
        private IApplicationQuery _applicationQuery { get; }
       [BindProperty] public CustomerViewModel cust { get; set; }

        public DetailModel(IApplicationQuery applicationQuery)
        {
            _applicationQuery = applicationQuery;
            cust = new();
        }

        public async Task<IActionResult> OnGet([FromRoute(Name = "food")] string id)
        {
            var result = await _applicationQuery.GetCustomerById(id);
            if(result == null) return BadRequest(); 
            cust.id = result!.id;
            cust.Price = result.Price;
            cust.Image = result.Image;
            cust.FoodTypeName = result.FoodTypeName;
            cust.CategoryName= result.CategoryName;
            cust.Name = result.Name;
            cust.Description = result.Description;
            return Page();
        }

        public  void OnPost()
        {
            
        }
    }
}

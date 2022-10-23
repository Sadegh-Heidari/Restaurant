using Acc.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Query;
using Resturan.Application.Query.DTO;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.ShoppingCart;
using Resturan.Presentation.Filters;
using Resturan.Presentation.Pages.Customer.Home.ViewModel;

namespace Resturan.Presentation.Pages.Customer
{
    [Authorize]
    [ValidationModelState]
    public class DetailModel : PageModel
    {
        private IApplicationQuery _applicationQuery { get; }
        private IUserApplication _userApplication { get; }
        private IApplicationShoppingCart _shoppingCart { get; }
        private CustomerDto _customer { get; set; }
       [BindProperty] public CustomerViewModel cart { get; set; }
        private CreatShoppingCartDto _creatShoppingCart { get; set; }
        private OperationShoppingDto _operationShopping { get; set; }
        public DetailModel(IApplicationQuery applicationQuery, IUserApplication userApplication, IApplicationShoppingCart shoppingCart)
        {
            _applicationQuery = applicationQuery;
            _userApplication = userApplication;
            _shoppingCart = shoppingCart;
            cart = new();
            _customer = new();
            _creatShoppingCart = new();
            _operationShopping = new();
        }

        public async Task<IActionResult> OnGet([FromRoute(Name = "food")] string id)
        {
            var result = await _applicationQuery.GetMenuItemQueryByIdAsync(id);
            if(result == null) return BadRequest(); 
            cart.id = result!.id;
            cart.Price = result.Price;
            cart.Image = result.Image;
            cart.FoodTypeName = result.FoodTypeName;
            cart.CategoryName= result.CategoryName;
            cart.Name = result.Name;
            cart.Description = result.Description;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                if (cart.id == null) return BadRequest();
                _customer.id = cart.id;
                var result = await _applicationQuery.GetPrice(_customer);
                cart.Price= result.Price;
            }

            var user = await _userApplication.FindUserAsync(User);
            if(user == null) return BadRequest();
            _operationShopping.MenuItemId = cart.id;
            _operationShopping.UserEmail = user.Email;
            var IsShop = await _shoppingCart.IsShoppingCartExist(_operationShopping);
            if (IsShop == true)
            {
                _operationShopping.Count = (short)cart.Count;
                var result = await _shoppingCart.IncrementCount(_operationShopping);
                if (result == true) return RedirectToPage("./Index");
                return BadRequest();
            }
            _creatShoppingCart.Email = user.Email;
            _creatShoppingCart.MenuItem = cart.id;
            _creatShoppingCart.UserName = user.UserName;
            _creatShoppingCart.Count = (short)cart.Count;
            await _shoppingCart.AddCart(_creatShoppingCart);
            return RedirectToPage("./Index");
        }
    }
}

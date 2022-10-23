using Acc.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.ShoppingCart;

namespace Resturan.Presentation.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private IApplicationShoppingCart _shoppingCart { get; }
        private IUserApplication _userApplication { get; }
        public IEnumerable<ShoppingCartDto> ShoppingCarts { get; set; }
        private GetShopCartDto _shoppingCartDto { get; set; }
        private OperationShoppingDto _operationShoppingDto { get; set; }
        public IndexModel(IApplicationShoppingCart shoppingCart, IUserApplication userApplication)
        {
            _shoppingCart = shoppingCart;
            _userApplication = userApplication;
            _shoppingCartDto = new();
            _operationShoppingDto = new();
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userApplication.FindUserAsync(User);
            if(user == null) return BadRequest();
            _shoppingCartDto.UserEmail = user.Email!;
            ShoppingCarts = await _shoppingCart.GetAllCart(_shoppingCartDto);
            return Page();
        }

        public async Task<IActionResult> OnPostDeIncrement([FromQuery(Name = "menu")] string? id)
        {
            var user = await _userApplication.FindUserAsync(User);
            if(user==null||id==null) return BadRequest();
            _operationShoppingDto.UserEmail = user.Email;
            _operationShoppingDto.MenuItemId = id;
            _operationShoppingDto.Count = 1;
            var result = await _shoppingCart.DeIncrementCount(_operationShoppingDto);
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostIncrement([FromQuery(Name = "menu")] string? id)
        {
            var user = await _userApplication.FindUserAsync(User);
            if (user == null || id == null) return BadRequest();
            _operationShoppingDto.UserEmail = user.Email;
            _operationShoppingDto.MenuItemId = id;
            _operationShoppingDto.Count = 1;
            var result = await _shoppingCart.IncrementCount(_operationShoppingDto);
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostDelete([FromQuery(Name = "menu")] string? id)
        {
            var user = await _userApplication.FindUserAsync(User);
            if (user == null || id == null) return BadRequest();
            _operationShoppingDto.UserEmail = user.Email;
            _operationShoppingDto.MenuItemId = id;
            var result = await _shoppingCart.DeleteCart(_operationShoppingDto);
            return RedirectToPage("./Index");
        }
    }
}

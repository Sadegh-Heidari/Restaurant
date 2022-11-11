using System.Globalization;
using System.Security.Claims;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.ShoppingCart;

namespace Resturan.Presentation.Tools
{
    public class CartShopCount
    {
        private IApplicationShoppingCart _shoppingCart { get; }

        public CartShopCount(IApplicationShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task CountCartCooki(HttpContext context)
        {
            var claim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            if (claim != null)
            {
                var  result = await _shoppingCart.GetCountCart(new FindShopCartDto { UserEmail = claim.Value });
                context.Session.SetInt32("cart",result);
                return;
            }

            return;
        }
    }
}

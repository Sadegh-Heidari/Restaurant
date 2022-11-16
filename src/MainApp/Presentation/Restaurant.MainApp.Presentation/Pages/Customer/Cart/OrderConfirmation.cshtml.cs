using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader;
using Restaurant.MainApp.Core.Application.Contract.DTO.ShoppingCart;
using Restaurant.MainApp.Infrastructure.Tools.Tools;
using Restaurant.MainApp.Presentation.Tools;
using Stripe;
using Stripe.Checkout;
using Session = Stripe.Checkout.Session;

namespace Restaurant.MainApp.Presentation.Pages.Customer.Cart
{
    [Authorize]
    public class OrderConfirmationModel : PageModel
    {
        private StripPayment strip { get; }
        private IApplicationOrder _applicationOrder { get; }
        private IApplicationStatus _applicationStatus { get; }
        private IApplicationShoppingCart _applicationShoppingCart { get; }
        public GetOrderHeader orderHeader { get; set; }
        private ChangeStatusOrder _changeStatusOrder { get; set; }
        private DeleteAllCart _deleteAllCart { get; set; }
        private CartShopCount _cartShop { get; }
        public OrderConfirmationModel(IOptions<StripPayment> strip,IApplicationOrder applicationOrder, IApplicationStatus applicationStatus, IApplicationShoppingCart applicationShoppingCart, CartShopCount cartShop)
        {
            _applicationOrder = applicationOrder;
            _applicationStatus = applicationStatus;
            _applicationShoppingCart = applicationShoppingCart;
            _cartShop = cartShop;
            _deleteAllCart = new();
            orderHeader = new();
            _changeStatusOrder = new();
            this.strip = strip.Value;
        }

        public async Task<IActionResult> OnGet([FromQuery]string id)
        {
            if(id==null) return BadRequest();
            orderHeader.OrderId = id;
            var find = await _applicationOrder.GetOrderHeader(orderHeader);
            if (find == null)
            {
                return BadRequest();
            }
            var service = new SessionService();
            StripeConfiguration.ApiKey = strip.SecretKey;
             Session session =  service.Get(find.SeesionId);
             if (session.PaymentStatus.ToLower() == "paid")
             {
                
                 _changeStatusOrder.OrderId = id;
                 _changeStatusOrder.Status = _applicationStatus.StatusSubmitted;
                 await _applicationOrder.ChangeStatusOrderHeader(_changeStatusOrder);

             }

             _deleteAllCart.UserEmail = find.UserEmail!;
            await _applicationShoppingCart.DeleteAllCart(_deleteAllCart);
            TempData["cart"] = await _cartShop.CountCartCooki(HttpContext);
            return Page();
        }
    }
}

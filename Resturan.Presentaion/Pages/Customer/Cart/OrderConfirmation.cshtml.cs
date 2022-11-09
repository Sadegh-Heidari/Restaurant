using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.OrderHeader;
using Resturan.Application.Service.DTO.ShoppingCart;
using Resturan.Infrastructure.Tools.Tools;
using Stripe;
using Stripe.Checkout;
using Session = Stripe.Checkout.Session;

namespace Resturan.Presentation.Pages.Customer.Cart
{
    [Authorize]
    public class OrderConfirmationModel : PageModel
    {
        private IApplicationOrder _applicationOrder { get; }
        private IApplicationStatus _applicationStatus { get; }
        private IApplicationShoppingCart _applicationShoppingCart { get; }
        public GetOrderHeader orderHeader { get; set; }
        private ChangeStatusOrder _changeStatusOrder { get; set; }
        private DeleteAllCart _deleteAllCart { get; set; }
        public OrderConfirmationModel(IApplicationOrder applicationOrder, IApplicationStatus applicationStatus, IApplicationShoppingCart applicationShoppingCart)
        {
            _applicationOrder = applicationOrder;
            _applicationStatus = applicationStatus;
            _applicationShoppingCart = applicationShoppingCart;
            _deleteAllCart = new();
            orderHeader = new();
            _changeStatusOrder = new();
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
            StripeConfiguration.ApiKey = StripPayment.SecretKey;
             Session session =  service.Get(find.SeesionId);
             if (session.PaymentStatus.ToLower() == "paid")
             {
                
                 _changeStatusOrder.OrderId = id;
                 _changeStatusOrder.Status = _applicationStatus.StatusSubmitted;
                 await _applicationOrder.ChangeStatusOrderHeader(_changeStatusOrder);

             }

             _deleteAllCart.UserEmail = find.UserEmail!;
            await _applicationShoppingCart.DeleteAllCart(_deleteAllCart);
            return Page();
        }
    }
}

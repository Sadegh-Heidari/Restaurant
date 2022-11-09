using Acc.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.OrderHeader;
using Resturan.Application.Service.DTO.ShoppingCart;
using Resturan.Infrastructure.Tools.Tools;
using Resturan.Presentation.Pages.Customer.Cart.ViewModels;
using Stripe;
using Stripe.Checkout;

namespace Resturan.Presentation.Pages.Customer.Cart
{
    [Authorize]
    public class SummaryModel : PageModel
    {
        private IApplicationShoppingCart _shoppingCart { get; }
        private IApplicationStatus _status { get; }
        private IApplicationOrder _applicationOrder { get; }
        private IUserApplication _userApplication { get; }
        private FindShopCartDto _findCart { get; set; }
        private OrderHeaderDto _orderHeader { get; set; }
        private List<OrderDetailDto> _orderDetail { get; set; }
        private DeleteAllCart _deleteAllCart { get; set; }
        private AddSesionPaymentDto _addSesionPayment { get; set; }
       [BindProperty] public SummaryViewModels SummaryView { get; set; }
       public IEnumerable<GetDetailsShoppingCart> DetailsShoppingCarts { get; set; }
        public SummaryModel(IApplicationShoppingCart shoppingCart, IApplicationOrder applicationOrder, IUserApplication userApplication, IApplicationStatus status)
        {
            _shoppingCart = shoppingCart;
            _applicationOrder = applicationOrder;
            _userApplication = userApplication;
            _status = status;
            _findCart = new();
            SummaryView = new();
            _orderHeader = new();
            _orderDetail = new List<OrderDetailDto>();
            _deleteAllCart = new();
            _addSesionPayment = new();
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userApplication.FindUserAsync(User);
            if (user == null)
            {
                return BadRequest();
            }

            _findCart.UserEmail = user.Email;
            DetailsShoppingCarts = await _shoppingCart.FindCart(_findCart);
            if (DetailsShoppingCarts.Count()==0) return BadRequest();
            SummaryView.PickupName = user.UserName;
            SummaryView.PhoneNumber = user.PhoneNumber;
            SummaryView.PickupDate=DateTime.Today;
            SummaryView.PickupTime=null;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userApplication.FindUserAsync(User);
            if (user == null)
            {
                return BadRequest();
            }
            _findCart.UserEmail = user.Email;
            DetailsShoppingCarts = await _shoppingCart.FindCart(_findCart);
            if (DetailsShoppingCarts.Count() == 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                SummaryView.PickupDate=DateTime.Today;
                return Page();
            }

            foreach (var item in DetailsShoppingCarts)
            {
                _orderHeader.OrderTotal += (Convert.ToDouble(item.Price) * item.Count);
                _orderDetail.Add(new OrderDetailDto
                {
                    Count = item.Count.ToString(),
                    MenuItemId = item.MenuItemId,
                    Price = item.Price,
                });
            }
            _orderHeader.PhoneNumber = SummaryView.PhoneNumber;
            _orderHeader.Comments=SummaryView.Comments;
            _orderHeader.PickupDate=SummaryView.PickupDate;
            _orderHeader.PickupName=SummaryView.PickupName;
            _orderHeader.PickupTime=SummaryView.PickupTime!.Value;
            _orderHeader.UserEmail = user.Email;
            _orderHeader.Status = _status.StatusPending;
            if (SummaryView.Comments == null) _orderHeader.Comments = "No Comment";
            else
            {
                _orderHeader.Comments = SummaryView.Comments;
            }
           var OrderId= await _applicationOrder.AddOrder(_orderHeader, _orderDetail);
           var domain = "https://localhost:7023/";
           StripeConfiguration.ApiKey = StripPayment.SecretKey;
           var options = new SessionCreateOptions
           {
               LineItems = new List<SessionLineItemOptions>()
               ,
               PaymentMethodTypes = new List<string>
               {
                   "card",
               },
               Mode = "payment",
               SuccessUrl = domain + $"Customer/Cart/OrderConfirmation?id={OrderId}",
               CancelUrl = domain + "Customer/Cart/Index",
           };

           //add line items
           foreach (var item in DetailsShoppingCarts)
           {
               var sessionLineItem = new SessionLineItemOptions
               {
                   PriceData = new SessionLineItemPriceDataOptions
                   {
                       //7.99->799
                       UnitAmount = (long)(Convert.ToDouble(item.Price) * 100),
                       Currency = "usd",
                       ProductData = new SessionLineItemPriceDataProductDataOptions
                       {
                           Name = item.Name
                       },
                   },
                   Quantity = item.Count
               };
               options.LineItems.Add(sessionLineItem);
           }
           var service = new SessionService();
           Session session = service.Create(options);
           Response.Headers.Add("Location", session.Url);
           _addSesionPayment.OrderId = OrderId;
           _addSesionPayment.SessionId = session.Id;
           _addSesionPayment.PaymentIntentId = session.PaymentIntentId;
           await _applicationOrder.AddSessionPayment(_addSesionPayment);
           return new StatusCodeResult(303);
        }
    }
}

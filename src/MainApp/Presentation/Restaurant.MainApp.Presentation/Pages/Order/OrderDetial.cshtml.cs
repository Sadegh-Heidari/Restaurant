using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader;
using Restaurant.MainApp.Infrastructure.Tools.Tools;
using Stripe;

namespace Restaurant.MainApp.Presentation.Pages.Order
{
    [Authorize(Roles = "Admin,FrontDesk")]
    public class OrderDetialModel : PageModel
    {
        private StripPayment strip { get; }
        private IApplicationOrder _applicationOrder { get; }
        private IApplicationStatus _applicationStatus { get; }
        private ChangeStatusOrder _changeStatus { get; set; }
        public GetOrderHeader? OrderHeader { get; set; }

        public IEnumerable<GetOrderDetails> OrderDetails { get; set; }

        public OrderDetialModel(IOptions<StripPayment> strip,IApplicationOrder applicationOrder, IApplicationStatus applicationStatus)
        {
            _applicationOrder = applicationOrder;
            _applicationStatus = applicationStatus;
            OrderHeader = new();
            _changeStatus = new();
            this.strip = strip.Value;
        }

        public async Task<IActionResult> OnGet([FromQuery] string OrderNumber)
        {
            if(OrderNumber == null) return BadRequest();
            
            OrderHeader = await _applicationOrder.GetOrderHeader(OrderNumber);
            OrderDetails = await _applicationOrder.GetOrderDetails(OrderNumber);
            return Page();
        }

        public async Task<IActionResult> OnGetOrderCompleted([FromQuery] string Ordernumber)
        {
            if(Ordernumber==null) return BadRequest();
            _changeStatus.Status = _applicationStatus.StatusCompleted;
            _changeStatus.OrderId = Ordernumber;
            await _applicationOrder.ChangeStatusOrderHeader(_changeStatus);
            return RedirectToPage("./OrderList");
        }
        public async Task<IActionResult> OnGetCancellOrder([FromQuery] string OrderNumber)
        {
            if (OrderNumber == null) return BadRequest();
            _changeStatus.OrderId=OrderNumber;
            _changeStatus.Status = _applicationStatus.StatusCancelled;
            await _applicationOrder.ChangeStatusOrderHeader(_changeStatus);
            return RedirectToPage("./OrderList");
        }

        public async Task<IActionResult> OnGetRefundOrder([FromQuery] string OrderNumber)
        {
            var order = await _applicationOrder.GetOrderHeader(OrderNumber);
            StripeConfiguration.ApiKey = strip.SecretKey;

            var options = new RefundCreateOptions
            {
                Reason = RefundReasons.RequestedByCustomer,
                PaymentIntent = order.PaymentIntentId
            };

            var service = new RefundService();
            Refund refund = service.Create(options);
            _changeStatus.OrderId = OrderNumber;
            _changeStatus.Status = _applicationStatus.StatusRefunded;
           await _applicationOrder.ChangeStatusOrderHeader(_changeStatus);
            return RedirectToPage("OrderList");
        }
    }
    
}

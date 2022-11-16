using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader;

namespace Restaurant.MainApp.Presentation.Pages.Order
{
    [Authorize(Roles = "Admin,Kitchen")]
    public class KitchenModel : PageModel
    {
        private IApplicationOrder _applicationOrder { get; }
        private IApplicationStatus _applicationStatus { get; }
        private ChangeStatusOrder _changeStatusOrder { get; set; }
        public IEnumerable<OrderKitchen> OredrKitchens { get; set; }
        public KitchenModel(IApplicationOrder applicationOrder, IApplicationStatus applicationStatus)
        {
            _applicationOrder = applicationOrder;
            _applicationStatus = applicationStatus;
            _changeStatusOrder = new();
        }

        public async Task OnGet()
        {
            OredrKitchens = await _applicationOrder.GetOrderKitchen(_applicationStatus.StatusSubmitted);
        }

        public async Task<IActionResult> OnPostCook([FromQuery] string OrderNumber)
        {
            if (OrderNumber == null) return BadRequest();
            _changeStatusOrder.OrderId = OrderNumber;
            _changeStatusOrder.Status = _applicationStatus.StatusInProcess;
            await _applicationOrder.ChangeStatusOrderHeader(_changeStatusOrder);
            return RedirectToPage("./Kitchen");
        }

        public async Task<IActionResult> OnPostReady([FromQuery] string OrderNumber)
        {
            if (OrderNumber == null) return BadRequest();
            _changeStatusOrder.OrderId = OrderNumber;
            _changeStatusOrder.Status = _applicationStatus.StatusReady;
            await _applicationOrder.ChangeStatusOrderHeader(_changeStatusOrder);
            return RedirectToPage("./Kitchen");
        }
        public async Task<IActionResult> OnPostCancel([FromQuery] string OrderNumber)
        {
            if (OrderNumber == null) return BadRequest();
            _changeStatusOrder.OrderId = OrderNumber;
            _changeStatusOrder.Status = _applicationStatus.StatusCancelled;
            await _applicationOrder.ChangeStatusOrderHeader(_changeStatusOrder);
            return RedirectToPage("./Kitchen");
        }
    }
}

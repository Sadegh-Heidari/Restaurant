using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader;

namespace Restaurant.MainApp.Presentation.Pages.Order
{
    [Authorize(Roles = "Admin,FrontDesk")]
    public class OrderListModel : PageModel
    {
        private IApplicationOrder _applicationOrder { get; }
        private  IApplicationStatus _applicationStatus { get; }
        public IEnumerable<GetOrderList> OrderList { get; set; }
        public OrderListModel(IApplicationOrder applicationOrder, IApplicationStatus applicationStatus)
        {
            _applicationOrder = applicationOrder;
            _applicationStatus = applicationStatus;
        }

        
        public async Task OnGet([FromQuery] string? status)
        {

            if (status == "cancelled")
            {
                OrderList = await _applicationOrder.GetOrderHeaderList(_applicationStatus.StatusCancelled);
            }
            else
            {
                if (status == "completed")
                {
                    OrderList = await _applicationOrder.GetOrderHeaderList(_applicationStatus.StatusCompleted);
                }
                else
                {
                    if (status == "ready")
                    {
                        OrderList = await _applicationOrder.GetOrderHeaderList(_applicationStatus.StatusReady);
                    }
                    
                    else
                    {
                        if (status == "InProcess")
                        {
                            OrderList= await _applicationOrder.GetOrderHeaderList(_applicationStatus.StatusInProcess);
                        }
                        else
                            OrderList = await _applicationOrder.GetOrderHeaderList(_applicationStatus.StatusSubmitted);
                    }
                }
            }
        }
    }
}

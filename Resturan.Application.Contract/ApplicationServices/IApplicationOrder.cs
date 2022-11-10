using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO.OrderHeader;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationOrder
    {
        Task<string> AddOrder(OrderHeaderDto dto,IEnumerable<OrderDetailDto> orDto);
        Task AddSessionPayment(AddSesionPaymentDto dto);
        Task<OrderHeaderDto?> GetOrderHeader(GetOrderHeader dto);
        Task<GetOrderHeader?> GetOrderHeader(string OrderNumber);
        Task ChangeStatusOrderHeader(ChangeStatusOrder dto);
        Task<IEnumerable<GetOrderList>> GetOrderHeaderList(string Status);
        Task<IEnumerable<GetOrderDetails>> GetOrderDetails(string OrderNumber);
    }
}

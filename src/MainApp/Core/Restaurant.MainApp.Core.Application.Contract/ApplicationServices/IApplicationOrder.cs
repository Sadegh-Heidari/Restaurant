using Restaurant.MainApp.Core.Application.Contract.DTO.OrderHeader;

namespace Restaurant.MainApp.Core.Application.Contract.ApplicationServices
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
        Task<IEnumerable<OrderKitchen>> GetOrderKitchen(string Status);
    }
}

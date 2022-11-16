using Restaurant.MainApp.Core.Application.Query.DTO;

namespace Restaurant.MainApp.Core.Application.Query;

public interface IApplicationQuery
{
    Task<IEnumerable<CustomerDto>> GetMenuItemQueryAsync();
    Task<CustomerDto?> GetMenuItemQueryByIdAsync(string id);
    Task<CustomerDto> GetPrice(CustomerDto dto);

}
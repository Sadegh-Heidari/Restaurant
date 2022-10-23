using System.Linq.Expressions;
using Resturan.Application.Query.DTO;

namespace Resturan.Application.Query;

public interface IApplicationQuery
{
    Task<IEnumerable<CustomerDto>> GetMenuItemQueryAsync();
    Task<CustomerDto?> GetMenuItemQueryByIdAsync(string id);
    Task<CustomerDto> GetPrice(CustomerDto dto);

}
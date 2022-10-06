using System.Linq.Expressions;
using Resturan.Application.Query.DTO;

namespace Resturan.Application.Query;

public interface IApplicationQuery
{
    Task<IEnumerable<CustomerDto>> GetCustomerQuery();
    Task<CustomerDto?> GetCustomerById(string id);
}
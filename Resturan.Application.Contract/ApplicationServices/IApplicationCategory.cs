using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationCategory:IDisposable
    {
        Task<Pageniation> GetAllCategory(Pageniation pg);
        Task Add(CreatCategoryDTO category);
        Task<bool> Update<T>(T entity) where T : CategoryDTO;
        Task<IEnumerable<CategoryDTO>> GetNameCategories();
        Task<CategoryDTO?> GetCategoryById(string id);
    }
}

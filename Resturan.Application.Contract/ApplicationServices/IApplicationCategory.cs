using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationCategory
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategory();
        Task Add(CreatCategoryDTO category);
        Task Update(UpdateCategoryDTO category);
        Task Delete(DeleteCategoryDTO guid);
    }
}

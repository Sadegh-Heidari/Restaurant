using Restaurant.MainApp.Core.Application.Contract.DTO;
using Restaurant.MainApp.Core.Application.Contract.DTO.Category;

namespace Restaurant.MainApp.Core.Application.Contract.ApplicationServices
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

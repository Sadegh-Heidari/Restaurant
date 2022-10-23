using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.FoodType;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationFoodType:IDisposable
    {
        Task<Pageniation> GetAllFoodType(Pageniation pg);
        Task Add(CreatFoodTypeDTO category);
        Task<bool> Update<T>(T entity) where T : FoodTypeDTO;
        Task<IEnumerable<FoodTypeDTO>> GetTypesFood();
        Task<FoodTypeDTO?> GetFoodTypeById(string id);
    }
}

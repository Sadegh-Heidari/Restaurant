using Restaurant.MainApp.Core.Application.Contract.DTO;
using Restaurant.MainApp.Core.Application.Contract.DTO.FoodType;

namespace Restaurant.MainApp.Core.Application.Contract.ApplicationServices
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

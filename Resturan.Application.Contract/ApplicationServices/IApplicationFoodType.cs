﻿using Resturan.Application.Service.DTO.FoodType;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationFoodType
    {
        Task<IEnumerable<FoodTypeDTO>> GetAllFoodType( int page, int pagesize);
        Task Add(CreatFoodTypeDTO category);
        Task<bool> Update<T>(T entity) where T : FoodTypeDTO;
        Task<IEnumerable<FoodTypeDTO>> GetTypesFood();
        Task<FoodTypeDTO?> GetFoodTypeById(string id);
    }
}

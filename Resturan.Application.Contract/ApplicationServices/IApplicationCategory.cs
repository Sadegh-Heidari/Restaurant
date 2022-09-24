﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationCategory
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategory();
        Task Add(CreatCategoryDTO category);
        Task Update<T>(T entity) where T : CategoryDTO;
    }
}
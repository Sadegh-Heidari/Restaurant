using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Domain.FoodType;
using Resturan.Domain.Services;

namespace Resturan.Application
{
    public class ApplicationFoodType:IApplicationFoodType
    {
        private IUnitOfWork _unitOfWork { get; }
        public ApplicationFoodType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Pageniation> GetAllFoodType(Pageniation pg)
        {
            pg.FoodType = await _unitOfWork.FoodTypeRepository.GetAllAsync(x => new FoodTypeDTO
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Guid,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
            },pg.PageSize,pg.PageNumber);
            pg.Count = await _unitOfWork.FoodTypeRepository.GetCount();
            return pg;
        }

        public async Task Add(CreatFoodTypeDTO category)
        {
            FoodTypeModel model = new(category.Name!);
           await _unitOfWork.FoodTypeRepository.AddAsync(model);
           _unitOfWork.Save();
        }

        public async Task<bool> Update<T>(T entity) where T:FoodTypeDTO
        {
            var model = await _unitOfWork.FoodTypeRepository.GetByFilter(x => x.Guid == entity.Id);
            if(model == null)return false;
            else if (typeof(T)==typeof(UpdateFoodTypeDTO))model.Update(entity.Name!);
            else if (typeof(T)==typeof(DeleteFoodTypeDTO))model.Delete();
            else if (typeof(T)==typeof(ActiveFoodTypeDTO))model.Active();
            _unitOfWork.FoodTypeRepository.Update(model);
            _unitOfWork.Save();
            return true;
        }

        public async Task<IEnumerable<FoodTypeDTO>> GetTypesFood()
        {
            var result = await _unitOfWork.FoodTypeRepository.GetAllAsync(x => new FoodTypeDTO()
            {
                Id = x.Guid,
                Name = x.Name,
            }, x => x.IsDeleted == false);
            return result;
        }

        public async Task<FoodTypeDTO?> GetFoodTypeById(string id)
        {
            var result = await _unitOfWork.FoodTypeRepository.GetByFilter(x => new FoodTypeDTO
            {
                Name = x.Name,
                Id = x.Guid
            }, x => x.Guid == id);
            return result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

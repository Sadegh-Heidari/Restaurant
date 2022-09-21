using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.ApplicationServices;
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

        public async Task<IEnumerable<FoodTypeDTO>> GetAllFoodType()
        {
            var result = await _unitOfWork.FoodTypeRepository.GetAsync(x => new FoodTypeDTO
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Guid,
                Name = x.Name
            }, x => x.IsDeleted == false);
            return result;
        }

        public async Task Add(CreatFoodTypeDTO category)
        {
            FoodTypeModel model = new(category.Name!);
           await _unitOfWork.FoodTypeRepository.AddAsync(model);
           _unitOfWork.Save();

        }

        public async Task Update<T>(T entity) where T:FoodTypeDTO
        {
            var model = await _unitOfWork.FoodTypeRepository.GetByIdAsync(x => x.Guid == entity.Id);
            if(model == null)return;
            if(typeof(T)==typeof(UpdateFoodTypeDTO))model.Update(entity.Name!);
            if(typeof(T)==typeof(DeleteFoodTypeDTO))model.Delete();
            _unitOfWork.FoodTypeRepository.Update(model);
            _unitOfWork.Save();
        }
    }
}

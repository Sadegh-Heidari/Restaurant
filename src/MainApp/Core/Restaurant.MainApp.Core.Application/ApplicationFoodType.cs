using System.Globalization;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Contract.DTO;
using Restaurant.MainApp.Core.Application.Contract.DTO.FoodType;
using Restaurant.MainApp.Core.Domain.FoodType;
using Restaurant.MainApp.Core.Domain.Services;

namespace Restaurant.MainApp.Core.Application
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
            var model = await _unitOfWork.FoodTypeRepository.GetByFilterAsync(x => x.Guid == entity.Id);
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
            var result = await _unitOfWork.FoodTypeRepository.GetByFilterAsync(x => new FoodTypeDTO
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

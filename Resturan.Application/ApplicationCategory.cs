using System.Globalization;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Domain.Category;
using Resturan.Domain.Services;

namespace Resturan.Application
{
    public class ApplicationCategory:IApplicationCategory
    {
        private IUnitOfWork _unitOfWork { get; }
        private IEnumerable<CategoryDTO>?_categoryDTO { get; set; }
        public ApplicationCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            var result = await _unitOfWork.CategoryRepository.GetAsync(x => new CategoryDTO()
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                DisplayOrder = x.DisplayOrder,
                GUID = x.Guid,
                Name = x.Name
            },x=>x.IsDeleted==false);
            return result;
        }

        public async Task Add(CreatCategoryDTO category)
        {
            var entity = new CategoryModel(category.DisplayOrder, category.Name!);
            await _unitOfWork.CategoryRepository.AddAsync(entity);
            _unitOfWork.Save();
        }

        public async Task Update<T>(T entity) where T : CategoryDTO
        {
            var model = await _unitOfWork.CategoryRepository.GetByIdAsync(x => x.Guid == entity.GUID);
            if (model == null) return;
            if (typeof(T) == typeof(UpdateCategoryDTO)) model.Update(entity.DisplayOrder,entity.Name!);
            if (typeof(T) == typeof(DeleteCategoryDTO)) model.Delete();
            _unitOfWork.CategoryRepository.Update(model);
            _unitOfWork.Save();
        }

      
    }
}

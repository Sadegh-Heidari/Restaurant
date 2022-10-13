using System.Globalization;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
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
        public ApplicationCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Pageniation> GetAllCategory(Pageniation pg)
        {
            
            pg.category = await _unitOfWork.CategoryRepository.GetAllAsync(x => new CategoryDTO()
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                DisplayOrder = x.DisplayOrder,
                GUID = x.Guid,
                Name = x.Name,
                IsDeleted = x.IsDeleted,
            }, pg.PageSize, pg.PageNumber);
            pg.Count = _unitOfWork.CategoryRepository.GetCount();
            var result = pg;
            return result;
        }

        public async Task Add(CreatCategoryDTO category)
        {
            var entity = new CategoryModel(category.DisplayOrder, category.Name!);
            await _unitOfWork.CategoryRepository.AddAsync(entity);
            _unitOfWork.Save();
        }

        public async Task<bool> Update<T>(T entity) where T : CategoryDTO
        {
            var model = await _unitOfWork.CategoryRepository.GetByIdAsync(x => x.Guid == entity.GUID, false);
            if (model == null) return false;
            else if (typeof(T) == typeof(UpdateCategoryDTO)) model.Update(entity.DisplayOrder,entity.Name!);
            else if(typeof(T) == typeof(DeleteCategoryDTO)) model.Delete();
            else if (typeof(T) == typeof(ActiveCategoryDTO)) model.Active();
            _unitOfWork.CategoryRepository.Update(model);
            _unitOfWork.Save();
            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetNameCategories()
        {

            var result = await _unitOfWork.CategoryRepository.GetAllAsync(x => new CategoryDTO
            {
                GUID = x.Guid,
                Name = x.Name,
            }, x => x.IsDeleted == false);
            return result;
        }

        public Task<CategoryDTO?> GetCategoryById(string id)
        {
            var result = _unitOfWork.CategoryRepository.GetByIdAsync(x => new CategoryDTO
            {
                GUID = x.Guid,
                Name = x.Name,
                DisplayOrder = x.DisplayOrder,
            }, x => x.Guid==id);
            return result;
        }

      
    }
}

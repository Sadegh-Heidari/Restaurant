using System.Globalization;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
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
            
            var result = await _unitOfWork.CategoryRepository.GetAllAsync();
            return result.Select(x => new CategoryDTO()
            {
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                DisplayOrder = x.DisplayOrder,
                GUID = x.Guid,
                Name = x.Name
            });
        }

        public async Task Add(CategoryDTO category)
        {
            var entity = new CategoryModel(category.DisplayOrder, category.Name!);
            await _unitOfWork.CategoryRepository.AddAsync(entity);
            _unitOfWork.Save();
        }

        public async Task Update(CategoryDTO category)
        {
            var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(x => x.Guid == category.GUID);
           entity!.Update(category.DisplayOrder,category.Name!);
            _unitOfWork.CategoryRepository.Update(entity);
            _unitOfWork.Save();
        }

        public async Task Delete(string guid)
        {
            var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(x => x.Guid == guid);
            entity!.Delete();
            _unitOfWork.CategoryRepository.Update(entity);
            _unitOfWork.Save();
        }
    }
}

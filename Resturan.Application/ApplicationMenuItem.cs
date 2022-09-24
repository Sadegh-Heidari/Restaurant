using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.MenuItem;
using Resturan.Domain.MenuItem;
using Resturan.Domain.Services;

namespace Resturan.Application
{
    public class ApplicationMenuItem : IApplicationMenuItem
    {
        private IUnitOfWork _unitOfWork { get; }

        public ApplicationMenuItem(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddItem(CreatMenuItem dto)
        {
            MenuItemModel model = new(dto.Name!, dto.Descriptaion!, dto.Image!, dto.Price!, dto.FoodType!, dto.Category!);
            await _unitOfWork!.MenuItemRepository.AddAsync(model);
            _unitOfWork.Save();
        }
    }
}

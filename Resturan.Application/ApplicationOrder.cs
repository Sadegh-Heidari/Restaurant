using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.OrderHeader;
using Resturan.Domain.Order;
using Resturan.Domain.OrderDetail;
using Resturan.Domain.Services;

namespace Resturan.Application
{
    public class ApplicationOrder:IApplicationOrder
    {
        private IUnitOfWork _unitOfWork { get; }

        public ApplicationOrder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrderHeader(OrderHeaderDto dto, IEnumerable<OrderDetailDto> orDto)
        {
            var model = new OrderHeaderModel(dto.UserEmail!, dto.PickupName!, dto.PhoneNumber!, dto.Comments!, dto.OrderTotal,
                dto.Status!, dto.PickupTime, dto.PickupDate);
            await _unitOfWork.OrderHeader.AddAsync(model);
           foreach (var item in orDto)
           {
               var order = new OrderDetailModel(model.Guid!, item.MenuItemId!, item.Count!, item.Price!);
              await _unitOfWork.OrderDetail.AddAsync(order);
           }
            _unitOfWork.Save();
        }

    }
}

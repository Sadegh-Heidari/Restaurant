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

        public async Task<string> AddOrder(OrderHeaderDto dto, IEnumerable<OrderDetailDto> orDto)
        {
            var model = new OrderHeaderModel(dto.UserEmail!, dto.PickupName!, dto.PhoneNumber!, dto.Comments!, (float)dto.OrderTotal,
                dto.Status!, dto.PickupTime, dto.PickupDate);
            await _unitOfWork.OrderHeader.AddAsync(model);
           foreach (var item in orDto)
           {
               var order = new OrderDetailModel(model.Guid!, item.MenuItemId!, item.Count!, item.Price!);
              await _unitOfWork.OrderDetail.AddAsync(order);
           }
            _unitOfWork.Save();
            return model.Guid!;
        }

        public async Task AddSessionPayment(AddSesionPaymentDto dto)
        {
            var findModel = await _unitOfWork.OrderHeader.GetOrderHeaderAsync(x => x.Guid == dto.OrderId);
            findModel!.AddPayment(dto.SessionId,dto.PaymentIntentId);
            _unitOfWork.OrderHeader.Update(findModel);
            _unitOfWork.Save();
        }

        public async Task<OrderHeaderDto?> GetOrderHeader(GetOrderHeader dto)
        {
            var model = await _unitOfWork.OrderHeader.GetByFilterAsync(x => new OrderHeaderDto()
            {
                 Comments = x.Comments,
                OrderTotal = x.OrderTotal,
                PaymentIntentId = x.PaymentIntentId,
                PickupTime = x.PickupTime,
                PhoneNumber = x.PhoneNumber,
                PickupDate = x.PickupDate,
                PickupName = x.PickupName,
                SeesionId = x.SessionId,
                Status = x.Status,
                UserEmail = x.Email
            }, x => x.Guid == dto.OrderId);
           
           return model;
        }

        public async Task ChangeStatusOrderHeader(ChangeStatusOrder dto)
        {
            var model = await _unitOfWork.OrderHeader.GetOrderHeaderAsync(x => x.Guid == dto.OrderId);
           model!.ChangeStatus(dto.Status);
           _unitOfWork.OrderHeader.Update(model);
           _unitOfWork.Save();

        }
    }
}

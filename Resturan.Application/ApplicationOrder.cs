﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO.OrderHeader;
using Resturan.Domain.Order;
using Resturan.Domain.OrderDetail;
using Resturan.Domain.Services;

namespace Resturan.Application
{
    public class ApplicationOrder:IApplicationOrder,IDisposable
    {
        private IUnitOfWork _unitOfWork { get; }
        private IApplicationStatus _applicationStatus { get; }
        public ApplicationOrder(IUnitOfWork unitOfWork, IApplicationStatus applicationStatus)
        {
            _unitOfWork = unitOfWork;
            _applicationStatus = applicationStatus;
        }

        public async Task<string> AddOrder(OrderHeaderDto dto, IEnumerable<OrderDetailDto> orDto)
        {
            var model = new OrderHeaderModel(dto.UserEmail!, dto.PickupName!, dto.PhoneNumber!, dto.Comments!, (float)dto.OrderTotal,
                dto.Status!, dto.PickupTime, dto.PickupDate);
            await _unitOfWork.OrderHeader.AddAsync(model);
            _unitOfWork.Save();
           foreach (var item in orDto)
           {
               var order = new OrderDetailModel(model.OrderNumber!, item.MenuItemId!, item.Count!, item.Price!);
              await _unitOfWork.OrderDetail.AddAsync(order);
           }
            _unitOfWork.Save();
            return model.OrderNumber.ToString();
        }

        public async Task AddSessionPayment(AddSesionPaymentDto dto)
        {
            var id = Convert.ToInt32(dto.OrderId);
            var findModel = await _unitOfWork.OrderHeader.GetOrderHeaderAsync(x => x.OrderNumber==id);
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
            }, x => x.OrderNumber == Convert.ToInt32(dto.OrderId));
           
           return model;
        }

        public async Task<GetOrderHeader?> GetOrderHeader(string OrderNumber)
        {
            var model = await _unitOfWork.OrderHeader.GetByFilterAsync(x => new GetOrderHeader
            {
                Comment = x.Comments,
                Email = x.Email,
                Name = x.PickupName,
                OrderTotal = x.OrderTotal.ToString(),
                PickupTime = x.PickupTime.ToString(),
                PhoneNumber = x.PhoneNumber,
                status = x.Status,
                OrderNumber = Convert.ToInt32(OrderNumber),
                PaymentIntentId = x.PaymentIntentId,
            }, x => x.OrderNumber == Convert.ToInt32(OrderNumber));
            return model;
        }

        public async Task ChangeStatusOrderHeader(ChangeStatusOrder dto)
        {
            var model = await _unitOfWork.OrderHeader.GetOrderHeaderAsync(x => x.OrderNumber == Convert.ToInt32(dto.OrderId));
           model!.ChangeStatus(dto.Status);
           _unitOfWork.OrderHeader.Update(model);
           _unitOfWork.Save();

        }

        public async Task<IEnumerable<GetOrderList>> GetOrderHeaderList(string Status)
        {
            var result = await _unitOfWork.OrderHeader.GetAllAsync(x => new GetOrderList
            {
                Email = x.Email,
                Name = x.PickupName,
                OrderNumber = x.OrderNumber,
                OrderTotal = x.OrderTotal.ToString(),
                PickupTime = x.PickupTime.ToString(),
                Status = x.Status,
            }, x => x.Status == Status);
            return result;
        }

        public async Task<IEnumerable<GetOrderDetails>> GetOrderDetails(string OrderNumber)
        {
            var model = await _unitOfWork.OrderDetail.GetAllAsync(x=>new GetOrderDetails
            {
                Count = x.Count,
                FoodName = x.MenuItem.Name,
                Price = x.Price,
            },x=>x.OrderID==Convert.ToInt32(OrderNumber));
            return model;
        }

        public async Task<IEnumerable<OrderKitchen>> GetOrderKitchen(string Status)
        {
            List<OrderKitchen> Kitchen = new List<OrderKitchen>();
            var resultheadr = await _unitOfWork.OrderHeader.GetAllAsync(x => new GetOrderList
            {
                Comment = x.Comments,
                Email = x.Email,
                Name = x.PickupName,
                OrderTotal = x.OrderTotal.ToString(),
                PickupTime = x.PickupTime.ToString(),
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                OrderNumber = Convert.ToInt32(x.OrderNumber),
            }, x => x.Status == Status||x.Status==_applicationStatus.StatusInProcess);
            foreach (var item in resultheadr)
            {
                var de = await _unitOfWork.OrderDetail.GetAllAsync(x => new GetOrderDetails
                {
                    Count = x.Count,
                    FoodName = x.MenuItem.Name,
                    Price = x.Price
                }, x => x.OrderID == item.OrderNumber);
                var result = new OrderKitchen
                {
                    OrderList = item,
                    OrderDetails = de
                };
                Kitchen.Add(result);
            }
            return Kitchen;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class GetOrderHeader:IDisposable
    {
        public string? OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderTotal { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string PickupTime { get; set; }
        public string PaymentIntentId { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

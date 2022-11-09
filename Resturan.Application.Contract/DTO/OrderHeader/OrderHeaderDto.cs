﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.OrderHeader
{
    public class OrderHeaderDto:IDisposable
    {
        
        public string? UserEmail { get;  set; }
        public string? PickupName { get;  set; }
        public string? PhoneNumber { get;  set; }
        public string? Comments { get;  set; }
        public double OrderTotal { get;  set; }
        public string? Status { get;  set; }
        public string? SeesionId { get; set; }
        public string? PaymentIntentId { get; set; }
        public DateTime PickupTime { get;  set; }
        public DateTime PickupDate { get;  set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

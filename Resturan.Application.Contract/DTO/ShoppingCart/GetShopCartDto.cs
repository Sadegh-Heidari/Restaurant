﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.ShoppingCart
{
    public class GetShopCartDto:IDisposable
    {
        public string UserEmail { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

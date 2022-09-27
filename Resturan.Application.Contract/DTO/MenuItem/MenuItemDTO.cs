﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO.MenuItem
{
    public class MenuItemDTO:IDisposable
    {
        public virtual string? Id  { get; set; }
        public virtual string? Name { get;  set; }
        public virtual bool? IsDeletd { get; set; }
        public virtual string?  CreationDate { get; set; }
        public virtual string? Descriptaion { get; set; }
        public virtual string? Image { get; set; }
        public virtual string? Price { get;  set; }
        public virtual string? FoodTypeName { get;  set; }
        public virtual string? CategoryName { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

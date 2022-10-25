﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Domain.Services
{
    public interface IUnitOfWork:IDisposable
    {
        public IRepositoryCategory CategoryRepository { get; }
        public IRepositoryFoodType FoodTypeRepository { get; }
        public IRepositoryMenuItem MenuItemRepository { get; }
        public IShoppingCartRepository ShoppingCartRepository { get; }
        public IRepositoryOrderHeader OrderHeader { get; }
        public IRepositoryOrderDetail OrderDetail { get; }
        void Save();
    }
}

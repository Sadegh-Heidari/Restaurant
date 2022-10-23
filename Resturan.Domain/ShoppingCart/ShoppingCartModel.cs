using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Base;
using Resturan.Domain.MenuItem;

namespace Resturan.Domain.ShoppingCart
{
    public class ShoppingCartModel:BaseModel
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public short Count { get; private set; }
        public string MenuItemId { get; private set; }
        public MenuItemModel MenuItem { get; private set; }

        public ShoppingCartModel(string userName, string email, short count, string menuItemId)
        {
            UserName = userName;
            Email = email;
            Count = count;
            MenuItemId = menuItemId;
        }

        public void CangeCount(short count)
        {
            Count=count;
        }
    }
}

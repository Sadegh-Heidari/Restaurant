using Restaurant.MainApp.Core.Domain.Base;
using Restaurant.MainApp.Core.Domain.MenuItem;

namespace Restaurant.MainApp.Core.Domain.ShoppingCart
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

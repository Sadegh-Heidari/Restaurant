using Restaurant.MainApp.Core.Domain.Base;
using Restaurant.MainApp.Core.Domain.MenuItem;
using Restaurant.MainApp.Core.Domain.Order;

namespace Restaurant.MainApp.Core.Domain.OrderDetail
{
    public class OrderDetailModel:BaseModel
    {
        public int OrderID { get; private set; }
        public OrderHeaderModel OrderHeader { get; private set; }
        public string MenuItemId { get; private set; }
        public MenuItemModel MenuItem { get; private set; }
        public string Count { get; private set; }
        public string Price { get; private set; }

        protected OrderDetailModel()
        {
        }

        public OrderDetailModel(int orderId, string menuItemId, string count, string price)
        {
            OrderID = orderId;
            MenuItemId = menuItemId;
            Count = count;
            Price = price;
        }
    }
}

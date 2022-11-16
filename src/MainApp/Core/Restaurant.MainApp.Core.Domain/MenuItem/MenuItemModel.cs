using Restaurant.MainApp.Core.Domain.Base;
using Restaurant.MainApp.Core.Domain.Category;
using Restaurant.MainApp.Core.Domain.FoodType;
using Restaurant.MainApp.Core.Domain.OrderDetail;
using Restaurant.MainApp.Core.Domain.ShoppingCart;

namespace Restaurant.MainApp.Core.Domain.MenuItem
{
    public class MenuItemModel:BaseModel
    {
        public string Name { get; private set; }
        public string Descriptaion { get; private set; }
        public string Image { get; private set; }
        public string Price { get; private set; }
        public string FoodTypeId { get; private set; }
        public FoodTypeModel FoodType { get; private set; }
        public string CategoryId { get; private set; }
        public CategoryModel Category { get; private set; }
        public ICollection<ShoppingCartModel> ShoppingCart { get; private set; }
        public ICollection<OrderDetailModel> OrderDetailModels { get; private set; }

        public MenuItemModel(string name, string descriptaion, string image, string price, string foodTypeId, string categoryId)
        {
            Name = name;
            Descriptaion = descriptaion;
            Image = image;
            Price = price;
            FoodTypeId = foodTypeId;
            CategoryId = categoryId;
        }

        public void Update(string name, string descriptaion, string image, string price, string foodTypeId, string categoryId)
        {
            Name = name;
            Descriptaion = descriptaion;
            Image = image;
            Price = price;
            FoodTypeId = foodTypeId;
            CategoryId = categoryId;
        }
    }
}
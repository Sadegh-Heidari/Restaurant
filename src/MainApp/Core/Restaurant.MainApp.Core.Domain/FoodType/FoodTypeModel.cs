using Restaurant.MainApp.Core.Domain.Base;
using Restaurant.MainApp.Core.Domain.MenuItem;

namespace Restaurant.MainApp.Core.Domain.FoodType
{
    public class FoodTypeModel:BaseModel
    {
        public string? Name { get; private set; }
        public ICollection<MenuItemModel> MenuItems { get; private set; }

        protected FoodTypeModel()
        {
        }

        public FoodTypeModel(string Name)
        {
            this.Name = Name;
        }
        public void Update(string Name)
        {
            this.Name = Name;
           
        }
    }
}

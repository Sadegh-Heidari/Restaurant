using Restaurant.MainApp.Core.Domain.Base;
using Restaurant.MainApp.Core.Domain.MenuItem;

namespace Restaurant.MainApp.Core.Domain.Category
{
    public class CategoryModel:BaseModel
    {
        public short DisplayOrder { get; private set; }
        public string? Name { get; private set; }
        public ICollection<MenuItemModel> MenuItems { get; private set; }
        protected CategoryModel()
        {
        }

        public CategoryModel(short displayOrder,string Name):base()
        {
            this.Name = Name;
            DisplayOrder = displayOrder;
        }

        public void Update(short displayOrder, string Name)
        {
            this.Name = Name;
            DisplayOrder = displayOrder;
        }
    }
}

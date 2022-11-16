using Restaurant.MainApp.Core.Application.Contract.DTO.Category;
using Restaurant.MainApp.Core.Application.Contract.DTO.FoodType;
using Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem;

namespace Restaurant.MainApp.Core.Application.Contract.DTO
{
    public class Pageniation:IDisposable
    {
        public IEnumerable<CategoryDTO> category { get; set; }
        public IEnumerable<FoodTypeDTO> FoodType { get; set; }
        public IEnumerable<MenuItemDTO> MenuItem { get; set; }
        public  int  Count { get; set; }
        public  int  PageSize { get; set; }
        public  int  PageNumber { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

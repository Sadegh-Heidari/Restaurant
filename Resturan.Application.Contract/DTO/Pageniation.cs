using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO.Category;
using Resturan.Application.Service.DTO.FoodType;
using Resturan.Application.Service.DTO.MenuItem;

namespace Resturan.Application.Service.DTO
{
    public class Pageniation:IDisposable
    {
        public IEnumerable<CategoryDTO> category { get; set; }
        public IEnumerable<FoodTypeDTO> FoodType { get; set; }
        public IEnumerable<MenuItemDTO> MenuItem { get; set; }
        public  int  Count { get; set; }
        public  int  page { get; set; }
        public  int  pagesize { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Base;

namespace Resturan.Domain.Category
{
    public class CategoryModel:BaseModel
    {
        public short DisplayOrder { get; private set; }
        public virtual string? Name { get; private set; }

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

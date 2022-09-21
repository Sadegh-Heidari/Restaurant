using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Domain.Base;

namespace Resturan.Domain.FoodType
{
    public class FoodTypeModel:BaseModel
    {
        public string? Name { get; private set; }

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

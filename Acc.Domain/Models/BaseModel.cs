using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Domain.Models
{
    public class BaseModel
    {
        public  string Id { get; private set; }

        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

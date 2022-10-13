using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Domain.Models
{
    public class Role:BaseModel
    {
        public string RoleName { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        protected Role()
        {
        }

        public Role(string roleName):base()
        {
            RoleName = roleName;
        }
    }
}

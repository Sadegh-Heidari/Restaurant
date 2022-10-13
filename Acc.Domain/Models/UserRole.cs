using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Domain.Models
{
    public class UserRole
    {
        public string RoleId { get; private set; }
        public Role RoleModel { get; private set; }
        public string UserId { get; private set; }
        public Users UserModel { get; private set; }

        public UserRole(string roleId, string userId)
        {
            RoleId = roleId;
            UserId = userId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Domain.Services
{
    public interface IAccUnitOfWork:IDisposable
    {
        public IUserAccRepository UserAccRepository { get;  }
        public IRoleAccRepository RoleAccRepository { get;  }
        public IAccUserRoleRepository UserRoleRepository { get; }
        void SaveChanges();
        
    }
}

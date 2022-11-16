namespace Restaurant.UsersApp.Core.Domain.Services
{
    public interface IAccUnitOfWork:IDisposable
    {
        public IUserAccRepository UserAccRepository { get;  }
        public IRoleAccRepository RoleAccRepository { get;  }
        public IAccUserRoleRepository UserRoleRepository { get; }
        void SaveChanges();
        
    }
}

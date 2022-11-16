using Restaurant.UsersApp.Core.Domain.Services;
using Restaurant.UsersApp.Infrastructure.EFCore.Context;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Repository
{
    public class AccUnitOfWork:IAccUnitOfWork
    {
        private AccContext _context { get; }

        public AccUnitOfWork(AccContext context)
        {
            _context = context;
        }

        private IUserAccRepository? _UserAccRepository;
        private IRoleAccRepository? _RoleAccRepository;
        private IAccUserRoleRepository? _RoleUserRepository;
        public IUserAccRepository UserAccRepository
        {
            get
            {
                if (_UserAccRepository == null)
                {
                    _UserAccRepository = new UserAccRepository(_context);
                }
                return _UserAccRepository;
            }
        }

        public IRoleAccRepository RoleAccRepository
        {
            get
            {
                if (_RoleAccRepository == null)
                {
                    _RoleAccRepository = new RoleAccRepository(_context);
                }

                return _RoleAccRepository;
            }
        }

        public IAccUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_RoleUserRepository == null)
                {
                    _RoleUserRepository = new UserRoleRepository(context: _context);
                }

                return _RoleUserRepository;
            }
        }

        public void Dispose()
        {
           Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        private bool isDisposed = false;

        private void Dispose(bool disposing)
        {
            if (isDisposed) return;


            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }

            this.isDisposed = true;
        }
    }
}

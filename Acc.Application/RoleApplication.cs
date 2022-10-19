using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Services;
using Acc.Services.DTO;
using Acc.Services.Services;
using AccResources;

namespace Acc.Application
{
    public class RoleApplication:IRoleApplication
    {
        private IAccUnitOfWork _unitOfWork { get; }
        private IOperationValue _operationValue { get; }
        public RoleApplication(IAccUnitOfWork unitOfWork, IOperationValue operationValue)
        {
            _unitOfWork = unitOfWork;
            _operationValue = operationValue;
        }
        public async Task<IOperationValue> CreatRole(Role role)
        {
            var existRole =
                await _unitOfWork.RoleAccRepository.IsExistRole(x => x.RoleName.ToLower() == role.Name!.ToLower());
            if (existRole == true) return _operationValue.ShowResult(false, AccountResource.RoleIsExist);
             await _unitOfWork.RoleAccRepository.AddAsync(new Domain.Models.Role(role.Name!));
             _unitOfWork.SaveChanges();

            return _operationValue.ShowResult(true, AccountResource.RoleAdded);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var result = await _unitOfWork.RoleAccRepository.GetAllRole(x => new Role { Name = x.RoleName }, true);
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using Restaurant.UsersApp.Core.Application.Services.DTO;
using Restaurant.UsersApp.Core.Application.Services.Services;
using Restaurant.UsersApp.Core.Domain.Services;
using Restaurant.UsersApp.Core.Resources;

namespace Restaurant.UsersApp.Core.Application
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
        public async Task<IOperationValue> CreatRole(RoleDto roleDto)
        {
            var existRole =
                await _unitOfWork.RoleAccRepository.IsExistRole(x => x.RoleName.ToLower() == roleDto.Name!.ToLower());
            if (existRole == true) return _operationValue.ShowResult(false, AccountResource.RoleIsExist);
             await _unitOfWork.RoleAccRepository.AddAsync(new Domain.Models.Role(roleDto.Name!));
             _unitOfWork.SaveChanges();

            return _operationValue.ShowResult(true, AccountResource.RoleAdded);
        }

        public async Task<IEnumerable<RoleDto>> GetRoles()
        {
            var result = await _unitOfWork.RoleAccRepository.GetAllRole(x => new RoleDto { Name = x.RoleName }, true);
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Services;
using Acc.Services.DTO;
using Acc.Services.Services;

namespace Acc.Application
{
    public class RoleApplication:IRoleApplication
    {
        private IAccUnitOfWork _unitOfWork { get; }
        public RoleApplication(IAccUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreatRole(Role role)
        {
            var existRole =
                await _unitOfWork.RoleAccRepository.IsExistRole(x => x.RoleName.ToLower() == role.Name.ToLower());
            if (existRole == true) return false;
             await _unitOfWork.RoleAccRepository.AddAsync(new Domain.Models.Role(role.Name));
             return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;
using Acc.Domain.Services;
using Acc.Services.DTO;
using Acc.Services.HashPassword;
using Acc.Services.Services;

namespace Acc.Application
{
    public class UserApplication:IUserApplication
    {
        private IAccUnitOfWork _unitOfWork { get; }
        private IHashPassword _hash { get; }

        public UserApplication(IAccUnitOfWork unitOfWork, IHashPassword hash)
        {
            _unitOfWork = unitOfWork;
            _hash = hash;
        }

        public async Task<bool> CreatUserAsync(CreatUser userDTO)
        {
            var result = await _unitOfWork.UserAccRepository.IsExistUserAsync(x => x.Email == userDTO.Email);
            if (result == true) return false;
            var PasswordHashed = _hash.Hash(userDTO.Password);
           await _unitOfWork.UserAccRepository.AddAsync(new Users(userDTO.UserName, userDTO.Email, userDTO.PhoneNumber,
                PasswordHashed));
           return true;
        }

        public async Task<bool> AddRoleUserAsync(UserDTO userDTO, string RoleName)
        {
            var UserFind = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Id == userDTO.Id);
            var RoleFind = await _unitOfWork.RoleAccRepository.FindRoleAsync(x => x.RoleName.ToLower() == RoleName.ToLower());
            if (UserFind == null || RoleFind == null) return false;
            return await _unitOfWork.UserRoleRepository.AddUserRoleAsync(new UserRole(RoleFind.Id, UserFind.Id));
        }

        public async Task<UserDTO?> FindUserAsync(UserDTO userDTO)
        {
            var result = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Id == userDTO.Id, s => new UserDTO
            {
                Email = s.Email,
                Id = s.Id,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName,
            });
            return result;
        }
    }
}

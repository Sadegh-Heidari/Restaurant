using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;
using Acc.Domain.Services;
using Acc.Services.DTO;
using Acc.Services.HashPassword;
using Acc.Services.Services;
using AccResources;
using Role = Acc.Services.DTO.Role;

namespace Acc.Application
{
    public class UserApplication : IUserApplication
    {
        private IAccUnitOfWork _unitOfWork { get; }
        private IHashPassword _hash { get; }
        private IOperationValue _operationValue { get; }
        public UserApplication(IAccUnitOfWork unitOfWork, IHashPassword hash, IOperationValue operationValue)
        {
            _unitOfWork = unitOfWork;
            _hash = hash;
            _operationValue = operationValue;
        }

        public async Task<IOperationValue> CreatUserAsync(UserDTO userDTO)
        {

            var result = await _unitOfWork.UserAccRepository.IsExistUserAsync(x => x.Email == userDTO.Email);
            if (result == true) return _operationValue.ShowResult(false, AccountResource.UserIsExist);
            var PasswordHashed = _hash.Hash(userDTO.Password!);
            var user = new Users(userDTO.UserName!, userDTO.Email!, userDTO.PhoneNumber!, PasswordHashed);
            await _unitOfWork.UserAccRepository.AddAsync(user);
            _unitOfWork.SaveChanges();
            return _operationValue.ShowResult(true, AccountResource.UserAdded);
        }

        public async Task<IOperationValue> AddRoleUserAsync(UserDTO userDTO, string RoleName)
        {
            var UserFind = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Email == userDTO.Email);
            var RoleFind = await _unitOfWork.RoleAccRepository.FindRoleAsync(x => x.RoleName.ToLower() == RoleName.ToLower());
            if (UserFind == null)
                return _operationValue.ShowResult(false, AccountResource.UserIsNotExist);
            if (RoleFind == null)
                return _operationValue.ShowResult(false, AccountResource.RoleIsNotExist);
            if (await _unitOfWork.UserRoleRepository.IsExistUserRoleAsync(new UserRole(RoleFind.Id, UserFind.Id)))
                return _operationValue.ShowResult(false, AccountResource.UserRoleIsExist);
            var result = await _unitOfWork.UserRoleRepository.AddUserRoleAsync(new UserRole(RoleFind.Id, UserFind.Id));
            if (!result)
                return _operationValue.ShowResult(false, AccountResource.Operation);
            _unitOfWork.SaveChanges();

            return _operationValue.ShowResult(true, AccountResource.UserRoleAdded);
        }

        public async Task<UserDTO?> FindUserByIdAsync(UserDTO userDTO)
        {
            var result = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Id == userDTO.Id, s => new UserDTO
            {
                Email = s.Email,
                Id = s.Id,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName,
                Password = s.Password
            });
            return result;
        }

        public async Task<IEnumerable<Role>> GetUserRole(UserDTO userDto)
        {
            var result = await _unitOfWork.UserRoleRepository.GetUserRole(s => new Role
            {
                Name = s.RoleModel.RoleName
            }, x => x.UserId == userDto.Id);
            return result;
        }

        public async Task<UserDTO?> FindUserByEmailAsync(UserDTO userDto)
        {
            var result = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Email == userDto.Email, s => new UserDTO
            {
                Email = s.Email,
                Id = s.Id,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName,
                Password = s.Password
            });
            return result;
        }

        public async Task<UserDTO?> FindUserByPhoneNumberAsync(UserDTO userDto)
        {
            var result = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.PhoneNumber == userDto.PhoneNumber, s => new UserDTO
            {
                Email = s.Email,
                Id = s.Id,
                PhoneNumber = s.PhoneNumber,
                UserName = s.UserName,
                Password = s.Password
            });
            return result;
        }

        public async Task<IOperationValue> IsUserExist(UserDTO userDto)
        {
            var result =
                await _unitOfWork.UserAccRepository.IsExistUserAsync(x=>x.Email == userDto.Email);
            if(result)
            {
                return _operationValue.ShowResult(true, AccountResource.UserIsExist);
            }

            return _operationValue.ShowResult(false, AccountResource.UserIsNotExist);
        }

        public async Task<Pagenition> GetUsers(Pagenition pg)
        {
            pg.users = await _unitOfWork.UserAccRepository.GetUsers(x => new UserDTO
            {
                UserName = x.UserName,
                Id = x.Id,
                Email = x.Email
            }, pg.PageSize, pg.PageNumber,x=>x.UserName!=AccountResource.Administrator);
            pg.Count = await _unitOfWork.UserAccRepository.GetCount();
            return pg;
        }

        public async Task<IOperationValue> DeleteUser(UserDTO userDTO)
        {
            var User = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Id == userDTO.Id);
            if (User==null) return _operationValue.ShowResult(false, AccountResource.UserIsNotExist);
            var UserDelete = _unitOfWork.UserAccRepository.DeleteEntity(User);
            if(UserDelete==false) return _operationValue.ShowResult(false, AccountResource.Operation);
            var RoleUser = await _unitOfWork.UserRoleRepository.GetUserRole(x => x.UserId == User.Id);
            if (RoleUser.Count() == 0)
            {
                _unitOfWork.SaveChanges();
                return _operationValue.ShowResult(true, AccountResource.DeleteUserSuccessfully);
            }

            var result = _unitOfWork.UserRoleRepository.DeleteUserRole(RoleUser);
            _unitOfWork.SaveChanges();
            return result == true
                ? _operationValue.ShowResult(true, AccountResource.DeleteUserSuccessfully)
                : _operationValue.ShowResult(false, AccountResource.DeleteUserUnSuccessfully);

        }

        public async Task<UserDTO?> FindUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            var user = claimsPrincipal.FindFirst(ClaimTypes.Email);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var result = await _unitOfWork.UserAccRepository.FindUserAsync(x => x.Email == user.Value,x=> new UserDTO
            {
                Email = x.Email,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
            },true);
            return result;
;        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

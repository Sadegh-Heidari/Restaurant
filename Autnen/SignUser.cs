using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Acc.Services.DTO;
using Acc.Services.HashPassword;
using Acc.Services.Services;
using AccResources;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Autnen
{
    public class SignUser:ISignUser
    {
        private IHttpContextAccessor _contextAccessor { get; }
        private IUserApplication _userApplication { get; }
        private IHashPassword _hashPassword { get; }
        private IOperationValue _operationValue { get; }
        public SignUser(IHttpContextAccessor contextAccessor, IUserApplication userApplication, IOperationValue operationValue, IHashPassword hashPassword)
        {
            _contextAccessor = contextAccessor;
            _userApplication = userApplication;
            _operationValue = operationValue;
            _hashPassword = hashPassword;
        }

        public async Task<IOperationValue> SignInAsync(UserDTO userDTO, bool IsPersistent = false)
        {
            var mac = GetMacAddress();
           var UserRole = await _userApplication.GetUserRole(userDTO);
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDTO.UserName!),
                new Claim(ClaimTypes.MobilePhone, userDTO.PhoneNumber!),
                new Claim(ClaimTypes.Email, userDTO.Email!),
                new Claim(ClaimTypes.System,mac),

            };
            if (UserRole.Count()!=0)
            {
                foreach (var roleName in UserRole)
                {
                    Claims.Add(new Claim(ClaimTypes.Role, roleName.Name!));
                }
            }

            var ClaimsIdentity= new ClaimsIdentity(Claims,Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(ClaimsIdentity);
            var authenticationProperties = new AuthenticationProperties
            {
                
                IsPersistent = IsPersistent
            };
            await _contextAccessor.HttpContext.SignInAsync(
                scheme: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme,
                principal: ClaimsPrincipal, properties: authenticationProperties);
            return _operationValue.ShowResult(true, AccountResource.SignInSuccessfully);
        }

        public async Task<IOperationValue> SignInWithPasswordAsync(UserDTO userDto, string Password, bool IsPersistent = false)
        {
            var mac = GetMacAddress();
            var CorrectPassword = _hashPassword.CheckPassword(userDto.Password!, Password);
            if (!CorrectPassword) return _operationValue.ShowResult(false,AccountResource.PasswordIsNotCorrect);
            var UserRole = await _userApplication.GetUserRole(userDto);
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDto.UserName!),
                new Claim(ClaimTypes.MobilePhone, userDto.PhoneNumber!),
                new Claim(ClaimTypes.Email, userDto.Email!),
                new Claim(ClaimTypes.System,mac),
            };
            if (UserRole.Count()!=0)
            {
                foreach (var roleName in UserRole)
                {
                    Claims.Add(new Claim(ClaimTypes.Role, roleName.Name!));
                }
            }

            var ClaimsIdentity = new ClaimsIdentity(Claims, Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(ClaimsIdentity);
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = IsPersistent
            };
            await _contextAccessor.HttpContext.SignInAsync(
                scheme: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme,
                principal: ClaimsPrincipal, properties: authenticationProperties);
            return _operationValue.ShowResult(true,AccountResource.SignInSuccessfully);
        }

        public void SignOutAsync()
        {
            _contextAccessor.HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies
                .CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private string GetMacAddress()
        {
            string result = "";
            foreach (NetworkInterface n in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (n.OperationalStatus == OperationalStatus.Up)
                {
                    result += n.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return result!;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

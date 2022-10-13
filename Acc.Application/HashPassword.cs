using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Services.HashPassword;
using static System.Net.Mime.MediaTypeNames;

namespace Acc.Application
{
    internal class HashPassword : IHashPassword
    {
        public string Hash(string password)
        {
            var inputBytes =
                System.Text.Encoding.UTF8.GetBytes(s: password);

            var sha =
                System.Security.Cryptography.SHA256.Create();

            var outputBytes =
                sha.ComputeHash(buffer: inputBytes);

            sha.Dispose();
            var result =
                System.Convert.ToBase64String(inArray: outputBytes);

            return result;
        }

        public bool CheckPassword(string Hash, string Password)
        {
            var inputBytes =
                System.Text.Encoding.UTF8.GetBytes(s: Password);

            var sha =
                System.Security.Cryptography.SHA256.Create();

            var outputBytes =
                sha.ComputeHash(buffer: inputBytes);

            sha.Dispose();

            var result =
                System.Convert.ToBase64String(inArray: outputBytes);

            if (result == Hash) return true;
            return false;
        }
    }
}

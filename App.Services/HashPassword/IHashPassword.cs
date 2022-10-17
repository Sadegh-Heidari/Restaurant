using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Services.HashPassword
{
    public interface IHashPassword:IDisposable
    {
        string Hash(string password);
        bool CheckPassword(string Hash,string Password);
    }
}

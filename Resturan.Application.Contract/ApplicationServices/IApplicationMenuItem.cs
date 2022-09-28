using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.MenuItem;

namespace Resturan.Application.Service.ApplicationServices
{
    public interface IApplicationMenuItem
    {
        Task AddItem(CreatMenuItem dto);
        Task<Pageniation > GetAllItems(Pageniation pg);
    }
}

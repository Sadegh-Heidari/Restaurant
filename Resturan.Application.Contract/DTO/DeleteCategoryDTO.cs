using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Application.Service.DTO
{
    public class DeleteCategoryDTO:UpdateCategoryDTO
    {
        public override string? GUID { get; set; }
    }
}

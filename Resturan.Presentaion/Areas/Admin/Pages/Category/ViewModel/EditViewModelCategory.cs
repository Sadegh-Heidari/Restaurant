using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Resturan.Presentation.Areas.Admin.Pages.Category.ViewModel
{
    public class EditViewModelCategory:CreatViewModelCategory
	{
        public string? Id { get; set; }
        
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturan.Presentation.Pages.Reg.ViewModel
{
    public class LoginViewModel:IDisposable
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
        public bool IsPersistent { get; set; } = false;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

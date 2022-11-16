using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Restaurant.MainApp.Infrastructure.Tools.Tools
{
    public class MaxSizeFileAttribute:ValidationAttribute,IClientModelValidator
    {
        private int MaxSize { get; }
        public MaxSizeFileAttribute(int maxSize)
        {
            MaxSize = maxSize;
        }

        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;
            return file==null?true:file.Length >=MaxSize?false:true;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if(String.IsNullOrWhiteSpace(ErrorMessageResourceName))
            context.Attributes.Add("data-val-MaxSizeFile",ErrorMessage!);
            else
            {
                context.Attributes.Add("data-val-MaxSizeFile", ErrorMessageString!);

            }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Myrmec;

namespace Restaurant.MainApp.Infrastructure.Tools.Tools
{
    public class FileExtensionAttribute : ValidationAttribute, IClientModelValidator
    {
        private List<Record> supportedFiles { get; set; }
        private Sniffer sniffer { get; }
        public FileExtensionAttribute()
        {
            supportedFiles = new()
            {
                new Record("jpeg", "ff,d8,ff,e0"),
                new Record("jpg", "FF,D9,FF,E8"),
                new Record("png", "89,50,4e,47,0d,0a,1a,0a"),
            };
            sniffer = new();
        }
        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;
            if (file == null) return false;
            sniffer.Populate(supportedFiles);
            var fileExtension = ReadFileHead(file);
            var result = sniffer.Match(fileExtension);
            if (result.Count > 0) return true;
            return false;
        }
        private byte[] ReadFileHead(IFormFile file)
        {
            using var fs = new BinaryReader(file.OpenReadStream());
            var bytes = new byte[200];
            fs.Read(bytes, 0, 20);
            return bytes;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            if (String.IsNullOrWhiteSpace(ErrorMessageResourceName))
                context.Attributes.Add("data-val-FileExtension", ErrorMessage!);
            else
            {
                context.Attributes.Add("data-val-FileExtension", ErrorMessageString!);

            }
        }

    }
}

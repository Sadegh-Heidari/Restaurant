using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Resturan.Infrastructure.Tools.Tools
{
    public static class ConvertImgToBase64String
    {
        public static async Task<string> Base64StringAsync(string path)
        {
            var img = await System.IO.File.ReadAllBytesAsync(path);
            var base64 = Convert.ToBase64String(img);
            return base64;
        }
        public static async Task<string> Base64StringAsync(Stream stream)
        {
            var result = await Task.Run(() =>
            {
                var ste = new BinaryReader(stream);
                var byt = ste.ReadBytes((int)stream.Length);
                var base64 = Convert.ToBase64String(byt);
                return base64;
            });
            return result;
        }
    }
}

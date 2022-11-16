namespace Restaurant.MainApp.Infrastructure.Tools.Tools
{
    public static class ConvertImgToBase64String
    {
        public static async Task<string> Base64StringAsync(string path)
        {
            var img = await System.IO.File.ReadAllBytesAsync(path);
            var base64 = Convert.ToBase64String(img);
            return base64;
        }
        public static string Base64StringAsync(Stream stream)
        {
           
                var ste = new BinaryReader(stream);
                var byt = ste.ReadBytes((int)stream.Length);
                var base64 = Convert.ToBase64String(byt);
                return base64;
           
        }
    }
}

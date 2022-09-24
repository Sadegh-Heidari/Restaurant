namespace Resturan.Presentation.Tools
{
    public class UploadImage
    {


        public static async Task<string> Send(IFormFile file, string Foolder,string rootpath)
        {
            var PathFoolder = Path.Combine(rootpath, Foolder);
            if (!File.Exists(PathFoolder))
            {
                Directory.CreateDirectory(PathFoolder);
            }
            var IsExistImage = Path.Combine(PathFoolder, file.FileName);
            if (!File.Exists(IsExistImage))
            {
                using (var fi = new FileStream(IsExistImage,FileMode.Create))
                {
                    await file.CopyToAsync(fi);
                    return Path.Combine(Foolder, file.FileName);
                }
            }
            return Path.Combine(Foolder, file.FileName);
        }
    }
}

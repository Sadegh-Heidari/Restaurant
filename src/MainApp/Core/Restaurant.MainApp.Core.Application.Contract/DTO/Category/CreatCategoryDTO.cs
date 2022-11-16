namespace Restaurant.MainApp.Core.Application.Contract.DTO.Category
{
    public class CreatCategoryDTO:IDisposable
    {
        public  string? Name { get; set; }
        public  short DisplayOrder { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

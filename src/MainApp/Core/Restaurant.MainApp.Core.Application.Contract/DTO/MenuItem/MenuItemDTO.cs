namespace Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem
{
    public class MenuItemDTO:IDisposable
    {
        public  string? Id  { get; set; }
        public  string? Name { get;  set; }
        public  bool? IsDeletd { get; set; }
        public  string?  CreationDate { get; set; }
        public  string? Descriptaion { get; set; }
        public  string? Image { get; set; }
        public  string? Price { get;  set; }
        public  string? FoodTypeName { get;  set; }
        public  string? CategoryName { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

namespace Restaurant.MainApp.Core.Application.Query.DTO
{
    public class CustomerDto:IDisposable
    {
        public string? id { get; set; }
        public string? CategoryName { get; set; }
        public string? FoodTypeName { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

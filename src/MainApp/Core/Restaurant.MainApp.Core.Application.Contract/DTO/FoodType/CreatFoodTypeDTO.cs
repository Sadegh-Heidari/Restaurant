namespace Restaurant.MainApp.Core.Application.Contract.DTO.FoodType
{
    public class CreatFoodTypeDTO:IDisposable
    {
        public  string? Name { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

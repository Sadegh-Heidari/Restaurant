namespace Restaurant.MainApp.Core.Application.Contract.DTO.FoodType
{
    public class FoodTypeDTO:IDisposable
    {
        public virtual string?  Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? CreationDate { get; set; }
        public virtual bool? IsDeleted { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

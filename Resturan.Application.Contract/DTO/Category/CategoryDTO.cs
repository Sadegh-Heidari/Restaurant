namespace Resturan.Application.Service.DTO.Category
{
    public class CategoryDTO:IDisposable
    {
        public virtual string?  GUID { get; set; }
        public virtual string?  Name { get; set; }
        public virtual string?  CreationDate { get; set; }
        public virtual short DisplayOrder { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

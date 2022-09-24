namespace Resturan.Domain.Base
{
    public class BaseModel
    {
        public virtual string? Guid { get; private set; }
        public virtual DateTime CreationDate { get; private set; }
        public virtual bool IsDeleted { get; private set; }
        public BaseModel()
        {
            
            this.Guid = System.Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Active()
        {
            IsDeleted = false;
        }
    }
}
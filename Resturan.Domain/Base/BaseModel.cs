namespace Resturan.Domain.Base
{
    public class BaseModel
    {
        public virtual string? Guid { get; private set; }
        public virtual string? Name { get; private set; }
        public virtual DateTime CreationDate { get; private set; }

        protected BaseModel()
        {
        }

        public BaseModel(string name)
        {
            Name = name;
            this.Guid = System.Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
        }
    }
}
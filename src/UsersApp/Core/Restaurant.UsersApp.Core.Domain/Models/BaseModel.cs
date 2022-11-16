namespace Restaurant.UsersApp.Core.Domain.Models
{
    public class BaseModel
    {
        public  string Id { get; private set; }

        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

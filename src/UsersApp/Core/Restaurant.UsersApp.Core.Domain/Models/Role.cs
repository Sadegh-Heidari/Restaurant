namespace Restaurant.UsersApp.Core.Domain.Models
{
    public class Role:BaseModel
    {
        public string RoleName { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        protected Role()
        {
        }

        public Role(string roleName):base()
        {
            RoleName = roleName;
        }
    }
}

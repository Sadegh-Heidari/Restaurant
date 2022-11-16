namespace Restaurant.UsersApp.Core.Domain.Models
{
    public class UserRole
    {
        public string RoleId { get; private set; }
        public Role RoleModel { get; private set; }
        public string UserId { get; private set; }
        public Users UserModel { get; private set; }

        public UserRole(string roleId, string userId)
        {
            RoleId = roleId;
            UserId = userId;
        }
    }
}

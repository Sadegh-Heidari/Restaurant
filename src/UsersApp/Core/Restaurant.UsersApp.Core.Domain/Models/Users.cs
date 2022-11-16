namespace Restaurant.UsersApp.Core.Domain.Models
{
    public class Users:BaseModel
    {
        public string UserName { get; private set; }
        public string  Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string  Password { get; private set; }
        public bool PhoneConfirmed { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        protected Users()
        {
        }

        public Users(string userName, string email, string phoneNumber, string password):base()
        {
            
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            PhoneConfirmed = false;
        }

        public void EditUser(string userName, string email, string phoneNumber)
        {
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void ChangePassword(string Pass)
        {
            Password = Pass;
        }

        public void PhoneConfirm(bool confirm)
        {
            PhoneConfirmed = confirm;
        }
    }
}

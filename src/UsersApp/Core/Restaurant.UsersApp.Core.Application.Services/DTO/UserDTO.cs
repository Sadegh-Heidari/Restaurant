namespace Restaurant.UsersApp.Core.Application.Services.DTO
{
    public class UserDTO:IDisposable
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

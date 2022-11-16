namespace Restaurant.UsersApp.Core.Application.Services.HashPassword
{
    public interface IHashPassword:IDisposable
    {
        string Hash(string password);
        bool CheckPassword(string Hash,string Password);
    }
}

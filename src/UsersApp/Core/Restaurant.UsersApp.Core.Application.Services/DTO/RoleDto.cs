namespace Restaurant.UsersApp.Core.Application.Services.DTO
{
    public class RoleDto:IDisposable
    {
        public string? Name { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

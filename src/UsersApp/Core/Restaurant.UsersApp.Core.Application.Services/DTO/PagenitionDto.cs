namespace Restaurant.UsersApp.Core.Application.Services.DTO
{
    public class PagenitionDto:IDisposable
    {
        public IEnumerable<UserDTO> users { get; set; }
        public long Count { get; set; }
        public int  PageSize { get; set; }
        public int PageNumber { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

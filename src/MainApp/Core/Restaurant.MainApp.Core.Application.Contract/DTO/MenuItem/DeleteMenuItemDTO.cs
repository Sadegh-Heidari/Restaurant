namespace Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem
{
    public class DeleteMenuItemDTO:IDisposable
    {
        public string? GUId { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

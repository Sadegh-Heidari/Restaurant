using Restaurant.MainApp.Core.Application.Contract.DTO;
using Restaurant.MainApp.Core.Application.Contract.DTO.MenuItem;

namespace Restaurant.MainApp.Core.Application.Contract.ApplicationServices
{
    public interface IApplicationMenuItem:IDisposable
    {
        Task AddItem(CreatMenuItem dto);
        Task<Pageniation > GetAllItems(Pageniation pg);
        Task<bool> DeleteItem(DeleteMenuItemDTO dto);
        Task<MenuItemDTO?> getItem(string id);
        Task<bool> UpdateItem(UpdateMenuItemDTO dto);
    }
}

using System.ComponentModel.DataAnnotations;
using Resturan.Infrastructure.Tools.Resource;

namespace Resturan.Presentation.Pages.Customer.Home.ViewModel
{
    public class CustomerViewModel:IDisposable
    {
        [Required]
        public string? id { get; set; }
        public string? CategoryName { get; set; }
        public string? FoodTypeName { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        [Range(1,100,ErrorMessageResourceType = typeof(ErrorMessagesResource),ErrorMessageResourceName = "OrderRang")]
        public int Count { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

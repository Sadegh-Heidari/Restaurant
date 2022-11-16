namespace Restaurant.MainApp.Core.Application.Contract.DTO.Category
{
    public class UpdateCategoryDTO:CategoryDTO
    {
        public override string? GUID { get; set; }
        public override string? Name { get; set; }
        public override short DisplayOrder { get; set; }


    }
}

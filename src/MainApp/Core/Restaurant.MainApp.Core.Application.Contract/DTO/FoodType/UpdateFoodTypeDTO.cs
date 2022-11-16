namespace Restaurant.MainApp.Core.Application.Contract.DTO.FoodType
{
    public class UpdateFoodTypeDTO:FoodTypeDTO
    {
        public override string? Id { get; set; }
        public override string? Name { get; set; }
    }
}

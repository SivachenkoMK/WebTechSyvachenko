using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Controllers.Dto;

public class DishModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Dish Name is required.")]
    public string Name { get; set; } = default!;
    
    [Required(ErrorMessage = "Dish Description is required.")]
    public string Description { get; set; } = default!;

    // TODO: Handle image in normal way - blob storage / CDN
    public IFormFile? Photo { get; set; }

    [Required(ErrorMessage = "Dish Price is required.")]
    public double Price { get; set; }

    public List<ReviewModel> Reviews { get; set; } = new();

    public List<CategoryModel> Categories { get; set; } = new();

    [Required(ErrorMessage = "Currency is required.")]
    public string Currency { get; set; } = default!;
}
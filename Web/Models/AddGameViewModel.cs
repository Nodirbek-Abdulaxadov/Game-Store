using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class AddGameViewModel
    {
        public AddGameViewModel()
        {
            SelectedCategories = new List<CategorySelect>();
        }
        [Required]
        public string? Name { get; set; }
        public decimal Price { get; set; } = 0;
        [Required]
        public string? Description { get; set; }
        [Required]
        public IFormFile? ImageFile { get; set; }
        [Required]
        public List<CategorySelect>? SelectedCategories { get; set; }
    }
}

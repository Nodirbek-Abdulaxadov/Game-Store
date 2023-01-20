using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class EditGameViewModel
    {
        public EditGameViewModel()
        {
            SelectedCategories = new List<CategorySelect>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal Price { get; set; } = 0;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
        [Required]
        public List<CategorySelect>? SelectedCategories { get; set; }
    }
}

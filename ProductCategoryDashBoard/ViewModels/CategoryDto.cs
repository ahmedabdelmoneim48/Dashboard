using System.ComponentModel.DataAnnotations;

namespace ProductCategoryDashBoard.ViewModels
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;
        public Boolean Active { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        public string Descrption { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "The image file is required")]
        public IFormFile ImageFile { get; set; }
    }
}

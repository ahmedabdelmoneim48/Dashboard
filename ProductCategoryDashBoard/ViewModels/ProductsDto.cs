using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoryDashBoard.ViewModels
{
    public class ProductsDto
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Brand is required")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Category is required")]
        public int SubCategoryId { get; set; }

        //[Required(ErrorMessage = "The Sub Category is required")]
        //public int SubCategoryId { get; set; }

        [Required(ErrorMessage = "The Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be a positive number")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The image file is required")]
        public IFormFile ImageFile { get; set; }
        
    }
}

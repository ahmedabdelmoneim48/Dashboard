using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCategoryDashBoard.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        [MaxLength(100)]
        public string ImageFileName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int OutOfStock { get; set; }


        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


    }
}

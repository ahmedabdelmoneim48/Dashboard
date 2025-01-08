using System.ComponentModel.DataAnnotations;

namespace ProductCategoryDashBoard.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public Boolean Active { get; set; } 
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } 
        public string Descrption { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;

        public List<Products> Products { get; set; } = new List<Products>();
        public List<SubCategory> SubCategories { get; set; }
    }
}

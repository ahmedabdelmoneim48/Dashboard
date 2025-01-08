using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoryDashBoard.ViewModels
{
    public class ProductsDto
    {     
        public string Name { get; set; } = string.Empty;
        
        public string Brand { get; set; } = string.Empty;
        
        
        public int CategoryId { get; set; } 
        
        public decimal Price { get; set; }
        
        public string Description { get; set; } = string.Empty;
        
        public IFormFile ImageFile { get; set; }
        
    }
}

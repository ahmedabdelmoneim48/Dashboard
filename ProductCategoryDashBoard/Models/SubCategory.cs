namespace ProductCategoryDashBoard.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public Boolean Active { get; set; } 
        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Products> Products { get; set; }
    }
}

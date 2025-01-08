namespace ProductCategoryDashBoard.ViewModels
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Boolean Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

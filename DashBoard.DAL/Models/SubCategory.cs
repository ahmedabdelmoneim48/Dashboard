namespace DashBoard.DAL.Models
{
    public class SubCategory : BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Descrption { get; set; } = string.Empty;
        public bool? Active { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public string ImageFileName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } 
        public List<Products> Products { get; set; }   
    }
}

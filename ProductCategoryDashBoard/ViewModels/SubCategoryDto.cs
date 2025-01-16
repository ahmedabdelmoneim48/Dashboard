using System.ComponentModel.DataAnnotations;

namespace DashBoard.PL.ViewModels
{
    public class SubCategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public int ProductsCount { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

using ProductCategoryDashBoard.Models;

namespace ProductCategoryDashBoard.ViewModels
{
    public class PaginationOfProductViewModel
    {
        public List<Products> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}

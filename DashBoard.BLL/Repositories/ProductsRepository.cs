using DashBoard.BLL.Interfaces;
using DashBoard.DAL.DBContext;
using DashBoard.DAL.Models;

namespace DashBoard.BLL.Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(AppDBContext context) : base(context)
        {
        }
    }
}

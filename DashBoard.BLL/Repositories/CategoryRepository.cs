using DashBoard.BLL.Interfaces;
using DashBoard.DAL.DBContext;
using DashBoard.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DashBoard.BLL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }
    }
}

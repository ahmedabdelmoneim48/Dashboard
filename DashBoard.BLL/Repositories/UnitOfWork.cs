using DashBoard.BLL.Interfaces;
using DashBoard.DAL.DBContext;

namespace DashBoard.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        private IProductsRepository productsRepository;
        private ICategoryRepository categoryRepository;

        public UnitOfWork(AppDBContext context) 
        {
            _context = context;
            productsRepository = new ProductsRepository(_context);
            categoryRepository = new CategoryRepository(_context);
        }

        public IProductsRepository ProductsRepository => productsRepository;
        public ICategoryRepository CategoryRepository => categoryRepository;


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); // Deallocate the unmanaged Resources in DB
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductsRepository ProductsRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        Task<int> Complete();
    }
}


using DashBoard.BLL.Interfaces;
using DashBoard.DAL.DBContext;
using DashBoard.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext _context;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }



        public async void Add(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<T> Get(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Products))
            {
                return (IEnumerable<T>) await _context.Products.Include(P => P.SubCategory).ToListAsync();
            }
            else if(typeof(T) == typeof(SubCategory))
            {
                return (IEnumerable<T>) await _context.SubCategories.Include(SC => SC.Products).ToListAsync();
            }
            else
            {
                return (IEnumerable<T>) await _context.Categories.Include(C => C.SubCategories).ToListAsync();
            }
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}

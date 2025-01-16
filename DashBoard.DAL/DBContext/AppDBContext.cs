using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DashBoard.DAL.DBContext.ClassConfigrations;
using DashBoard.DAL.Models;
using System.Reflection;

namespace DashBoard.DAL.DBContext
{
    public class AppDBContext : DbContext
    {


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public AppDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Offers> Offers { get; set; }


        
    }
}

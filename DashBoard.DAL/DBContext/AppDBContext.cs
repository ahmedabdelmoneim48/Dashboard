using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DashBoard.DAL.DBContext.ClassConfigrations;
using DashBoard.DAL.Models;

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

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            //modelBuilder.ApplyConfiguration(new SubCategoryConfigurations());
            //modelBuilder.ApplyConfiguration(new ProductsConfigrations());

        }
    }
}

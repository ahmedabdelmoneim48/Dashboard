using System.Numerics;
using Microsoft.EntityFrameworkCore;
using DashBoard.DAL.Models;
using DashBoard.DAL.DBContext;


namespace DashBoard.DAL.DBContext.SeedingData
{
    public class DataSeed
    {
        public static void SeedDatabase(AppDBContext context)
        {
            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Fruits",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "fruits.jpg"
                    },
                    new Category
                    {
                        Name = "Grocery",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "grocery.jpg"
                    },
                    new Category
                    {
                        Name = "Electronics",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "electronic.jpg"
                    }
                );
                context.SaveChanges();
            }

            if (!context.SubCategories.Any())
            {
                context.SubCategories.AddRange(
                    new SubCategory
                    {
                        Name = "Phones",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        CategoryId = 3
                    }
                );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {


                context.Products.AddRange(
                        new Products
                        {
                            Name = "Apples",
                            Brand = "apples",
                            CategoryId = 1,
                            Price = 1.50m,
                            Description = "american apples",
                            ImageFileName = "apples.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 10
                        },
                        new Products
                        {
                            Name = "Bananas",
                            Brand = "bananas",
                            CategoryId = 1,
                            Price = 0.50m,
                            Description = "egyptian bananas",
                            ImageFileName = "bananas.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 20
                        },
                        new Products
                        {
                            Name = "Watermelon",
                            Brand = "watermelon",
                            CategoryId = 1,
                            Price = 1.50m,
                            Description = "egyptian watermelon",
                            ImageFileName = "watermelon.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 30
                        },
                        new Products
                        {
                            Name = "Tomatos",
                            Brand = "tomatos",
                            CategoryId = 2,
                            Price = 0.25m,
                            Description = "egyptian tomatos",
                            ImageFileName = "tomatos.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 40
                        },
                        new Products
                        {
                            Name = "Lettuce",
                            Brand = "lettuce",
                            CategoryId = 2,
                            Price = 0.25m,
                            Description = "american lettuce",
                            ImageFileName = "lettuce.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 50
                        },
                        new Products
                        {
                            Name = "Carrots",
                            Brand = "carrots",
                            CategoryId = 2,
                            Price = 0.75m,
                            Description = "egyptian carrots",
                            ImageFileName = "carrots.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 60

                        }


                );
                context.SaveChanges();
            }

        }
    }
}

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
                        Name = "Grocery",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "fruits.jpg"
                    },
                    new Category
                    {
                        Name = "Milk",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "milk.jpg"
                    },
                    new Category
                    {
                        Name = "Electronics",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "electronic.jpg"
                    },
                    new Category
                    {
                        Name = "Bakery",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = string.Empty,
                        ImageFileName = "bakery.jpg"
                    }
                );
                context.SaveChanges();
            }

            if (!context.SubCategories.Any())
            {
                context.SubCategories.AddRange(
                    new SubCategory
                    {
                        Name = "Fruits",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "Fresh Fruits",
                        CategoryId = 1,
                        ImageFileName = "fruits.jpg"
                    },
                    new SubCategory
                    {
                        Name = "Vegetables",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "Fresh vegetables",
                        CategoryId = 1,
                        ImageFileName = "grocery.jpg"
                    },
                    new SubCategory
                    {
                        Name = "المرااعى",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "لبن طازج",
                        CategoryId = 2,
                        ImageFileName = "maraay.jpg"
                    },
                    new SubCategory
                    {
                        Name = "مزارع دينا",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "لبن طازج",
                        CategoryId = 2,
                        ImageFileName = "dinamilk.jpg"
                    },
                    new SubCategory
                    {
                        Name = "Phones",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "Electronic Phones SubCategory",
                        CategoryId = 3,
                        ImageFileName = "phones.jpg"
                    },
                    new SubCategory
                    {
                        Name = "Bread",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "Delecouis Bread",
                        CategoryId = 4,
                        ImageFileName = "bread.jpg"
                    },
                    new SubCategory
                    {
                        Name = "Corwason",
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Descrption = "Delecouis Corwason",
                        CategoryId = 4,
                        ImageFileName = "bread.jpg"
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
                            SubCategoryId = 1,
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
                            SubCategoryId = 1,
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
                            SubCategoryId = 1,
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
                            SubCategoryId = 2,
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
                            SubCategoryId = 2,
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
                            SubCategoryId = 2,
                            Price = 0.75m,
                            Description = "egyptian carrots",
                            ImageFileName = "carrots.jpg",
                            CreatedAt = DateTime.Now,
                            OutOfStock = 60
                        }


                );
                context.SaveChanges();
            }

            if (!context.Offers.Any())
            {
                //context.Offers.AddRange(
                //        new Offers
                //        {

                //        });
                        
                //context.SaveChanges();
            }

        }
    }
}

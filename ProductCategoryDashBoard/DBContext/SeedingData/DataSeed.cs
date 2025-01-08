using System.Numerics;
using Microsoft.EntityFrameworkCore;
using ProductCategoryDashBoard.Models;

namespace ProductCategoryDashBoard.DBContext.SeedingData
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
                        Name = "Fruits"
                    },
                    new Category
                    {
                        Name = "Grocery"
                    });
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
                            CreatedAt = DateTime.Now
                        },
                        new Products
                        {
                            Name = "Bananas",
                            Brand = "bananas",
                            CategoryId = 1,
                            Price = 0.50m,
                            Description = "egyptian bananas",
                            ImageFileName = "bananas.jpg",
                            CreatedAt = DateTime.Now
                        },
                        new Products
                        {
                            Name = "Watermelon",
                            Brand = "watermelon",
                            CategoryId = 1,
                            Price = 1.50m,
                            Description = "egyptian watermelon",
                            ImageFileName = "watermelon.jpg",
                            CreatedAt = DateTime.Now
                        },
                        new Products
                        {
                            Name = "Tomatos",
                            Brand = "tomatos",
                            CategoryId = 2,
                            Price = 0.25m,
                            Description = "egyptian tomatos",
                            ImageFileName = "tomatos.jpg",
                            CreatedAt = DateTime.Now
                        },
                        new Products
                        {
                            Name = "Lettuce",
                            Brand = "lettuce",
                            CategoryId = 2,
                            Price = 0.25m,
                            Description = "american lettuce",
                            ImageFileName = "lettuce.jpg",
                            CreatedAt = DateTime.Now
                        },
                        new Products
                        {
                            Name = "Carrots",
                            Brand = "carrots",
                            CategoryId = 2,
                            Price = 0.75m,
                            Description = "egyptian carrots",
                            ImageFileName = "carrots.jpg",
                            CreatedAt = DateTime.Now
                        }


                );


                //if (!context.Users.Any())
                //{
                //    context.Users.AddRange(
                //        new User
                //        {
                //            FirstName = "ahmed",
                //            LastName = "mohamed",
                //            Email = "ahmedmohamed@gmail.com",
                //            PasswordHash = "null",
                //            CreatedAt = DateTime.Now
                //        },
                //        new User
                //        {
                //            FirstName = "ali",
                //            LastName = "ali",
                //            Email = "ali@gmail.com",
                //            PasswordHash = "null",
                //            CreatedAt = DateTime.Now
                //        });
                //}
                //if (!context.Orders.Any())
                //{
                //    context.Orders.AddRange(
                //        new Order
                //        {
                //            UserId = 1,
                //            OrderDate = DateTime.Now,
                //            Status = "Pending"

                //        },
                //        new Order
                //        {
                //            UserId = 2,
                //            OrderDate = DateTime.Now,
                //            Status = "Pending"

                //        });
                //}


                //if (!context.OrderItems.Any())
                //{
                //    context.OrderItems.AddRange(
                //        new OrderItem
                //        {
                //            OrderId = 1,
                //            ProductId = 1,
                //            Quantity = 2,
                //            Price = 3m

                //        },
                //        new OrderItem
                //        {
                //            OrderId = 1,
                //            ProductId = 1,
                //            Quantity = 2,
                //            Price = 2m

                //        });
                //}
                context.SaveChanges();
            }

        }
    }
}

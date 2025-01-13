using Microsoft.EntityFrameworkCore;
//using ProductCategoryDashBoard.DBContext;
//using ProductCategoryDashBoard.DBContext.SeedingData;
using AutoMapper;
//using ProductCategoryDashBoard.DBContext.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using DashBoard.BLL.Interfaces;
using DashBoard.DAL.Models;
using DashBoard.DAL.DBContext;
using DashBoard.DAL.DBContext.SeedingData;
using ProductCategoryDashBoard.Helper.Mapping;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// AutoMapper Services
builder.Services.AddAutoMapper(typeof(MappingProfile));



//builder.Services.AddScoped<IProductsRepository>




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Seeding Data
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDBContext>();
DataSeed.SeedDatabase(context);




app.Run();

using DashBoard.DAL.DBContext;
using DashBoard.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategoryDashBoard.ViewModels;

namespace DashBoard.PL.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly AppDBContext _context;

        public SubCategoryController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id , int page = 1)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            var subCategory = await  _context.SubCategories.Include(p => p.Products).FirstOrDefaultAsync(sc => sc.Id == id);

            int pageSize = 5;
            int totalItems = subCategory.Products.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);//total Pages
            page = (page < 1) ? 1 : (page > totalPages) ? totalPages : page;


            var products = subCategory.Products
                                        .OrderByDescending(p => p.Price)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            if (!products.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new PaginationOfProductViewModel
            {
                Products = products,
                PageSize = pageSize,
                TotalPages = totalPages,
                CurrentPage = page
            };

            //ViewData["SubCategoryName"] = subCategory.Name;

            return View(model);
        }
    }
}

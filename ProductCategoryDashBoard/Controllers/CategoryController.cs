using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategoryDashBoard.DBContext;

namespace ProductCategoryDashBoard.Controllers
{
    public class CategoryController : Controller
    {
        public AppDBContext _context { get; set; }
        public IWebHostEnvironment _webHostEnvironment { get; }
        public IMapper _mapper { get; }

        public CategoryController(AppDBContext context , IWebHostEnvironment webHostEnvironment , IMapper mapper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //var categories = await _context.Categories.Include(c => c.Products).ToListAsync();

            var categories = await _context.Categories
            .Select(c => new
            {
                CategoryName = c.Name,
                ProductCount = c.Products.Count()
            })
            .ToListAsync();


            return View(categories);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}

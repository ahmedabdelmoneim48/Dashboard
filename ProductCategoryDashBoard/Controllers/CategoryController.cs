using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductCategoryDashBoard.DBContext;
using ProductCategoryDashBoard.Models;
using ProductCategoryDashBoard.ViewModels;

namespace ProductCategoryDashBoard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public CategoryController(AppDBContext context, IWebHostEnvironment webHostEnvironment, IMapper mapper)
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
                CategoryId = c.Id,
                CategoryName = c.Name,
                ProductCount = c.Products.Count(),
                SubCategoriesCount = c.SubCategories.Count(),
                SubCategories = c.SubCategories.Select(sc => new
                {
                    SubCategoryName = sc.Name,
                    ProductCount = sc.Products.Count()
                }),
                CategoryImage = c.ImageFileName,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();


            var categoriesWithActiveStatus = categories.Select(category => new
            {
                category.CategoryId,
                category.CategoryName,
                category.ProductCount,
                category.SubCategoriesCount,
                category.CategoryImage,
                category.CreatedAt,
                // Set Active to true if:
                // 1. Product count is greater than 1 OR
                // 2. There is any subcategory with products
                Active = category.ProductCount >= 1 || category.SubCategories.Any(sub => sub.ProductCount > 0)
            })
            .ToList();

           
            return View(categoriesWithActiveStatus);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (categoryDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "the image file is required");
            }
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == categoryDto.Name.ToLower());
            if (existingCategory != null)
            {
                ModelState.AddModelError("Name", "A Category with the same name already exists.");
                return View(categoryDto);
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(categoryDto.ImageFile.FileName);

            string imageFullPath = _webHostEnvironment.WebRootPath + "/CategoryImages/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                categoryDto.ImageFile.CopyTo(stream);
            }

            Category category = _mapper.Map<Category>(categoryDto);
            category.ImageFileName = newFileName;

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }




        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return RedirectToAction("Index", "Category");
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);

            ViewData["CategoryId"] = category.Id;
            ViewData["ImageFileName"] = category.ImageFileName;
            ViewData["CreatedIn"] = category.CreatedAt.ToString("MM/dd/yyyy");

            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryDto categoryDto)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction("Index", "Category");
            }

            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = category.Id;
                ViewData["ImageFileName"] = category.ImageFileName;
                ViewData["CreatedIn"] = category.CreatedAt.ToString("MM/dd/yyyy");

                return View(categoryDto);
            }

            /// Update image file if we have image uploaded new
            string newFileName = category.ImageFileName;
            if (categoryDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(categoryDto.ImageFile.FileName);

                string imageFullPath = _webHostEnvironment.WebRootPath + "/CategoryImages/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    categoryDto.ImageFile.CopyTo(stream);
                }

                // Deleting old image
                string oldImagePath = _webHostEnvironment.WebRootPath + "/CategoryImages/" + category.ImageFileName;
                System.IO.File.Delete(oldImagePath);
            }

            // update Category
            category.Name = categoryDto.Name;
            category.Descrption = categoryDto.Descrption;
            category.ImageFileName = newFileName;

            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }



        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return a 400 BadRequest if the model is invalid
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return RedirectToAction("Index", "Category");
            }

            bool HasProducts = category.Products.Any();
            if (HasProducts)
            {
                return RedirectToAction("Index", "Category");
            }

            bool HasSubCategory = category.SubCategories != null && category.SubCategories.Any();
            if (HasSubCategory)
            {
                return RedirectToAction("Index", "Category");
            }


            // remove image
            string imageFilePath = _webHostEnvironment.WebRootPath + "/CategoryImages/" + category.ImageFileName;
            System.IO.File.Delete(imageFilePath);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Category");

        }
    }

    
}

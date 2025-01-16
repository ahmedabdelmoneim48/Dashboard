using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DashBoard.DAL.DBContext;
using DashBoard.DAL.Models;
using ProductCategoryDashBoard.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProductCategoryDashBoard.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public ProductsController(AppDBContext context, IWebHostEnvironment environment, IMapper mapper)
        {
            _context = context;
            _environment = environment;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index( int page = 1)
        {
            int pageSize = 5;
            int totalItems = _context.Products.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);//total Pages

            page = (page <  1) ? 1 : (page > totalPages) ? totalPages : page;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index" , "Home");
            }
            var products = await  _context.Products.Include(p => p.SubCategory)
                                                   .Include(p => p.SubCategory.Category)
                                                   .OrderByDescending(p => p.Price)
                                                   .Skip((page - 1) * pageSize)
                                                   .Take(pageSize)
                                                   .ToListAsync();

            var model = new PaginationOfProductViewModel
            {
                Products = products,
                PageSize = pageSize,
                TotalPages = totalPages,
                CurrentPage = page
            };


            return View(model);
        }
        

        public async Task<IActionResult> Create()
        {

            var categories = await _context.Categories.ToListAsync();
            var subCategories = await _context.SubCategories.ToListAsync();
            // Pass the categories to the view
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.SubCategories = new SelectList(subCategories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductsDto productsDto)
        {
            if (productsDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "the image file is required");
            }
            if (!ModelState.IsValid)
            {
                return View(productsDto);
            }


            // Check If the product already exists, return an error message
            var existingProduct = await _context.Products
                                  .FirstOrDefaultAsync(p => p.Name.ToLower() == productsDto.Name.ToLower() &&
                                                            p.Brand.ToLower() == productsDto.Brand.ToLower() &&
                                                            p.Price == productsDto.Price);

            if (existingProduct != null)
            {
                ModelState.AddModelError("Name", "A product with the same name, brand, and price already exists.");
                return View(productsDto);
            }


            //saving image  
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(productsDto.ImageFile!.FileName);

            string imageFullPath = _environment.WebRootPath + "/ProductsImages/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                productsDto.ImageFile.CopyTo(stream);
            }

            Products product = _mapper.Map<Products>(productsDto);
            product.ImageFileName = newFileName;  // Manually mapping new image map

            //Products product = new Products()
            //{
            //    Name = productsDto.Name,
            //    Brand = productsDto.Brand,
            //    Category = productsDto.Category,
            //    Price = productsDto.Price,
            //    Description = productsDto.Description,
            //    ImageFileName = newFileName,
            //    CreatedIn = DateTime.Now
            //};

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }


        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FindAsync(id);
            //var productDto = _mapper.Map<ProductsDto>(product);
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _context.Categories.ToListAsync();

            // Pass the categories to the view
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            var productDto = _mapper.Map<ProductsDto>(product);

            ViewData["ProductId"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["CreatedIn"] = product.CreatedAt.ToString("MM/dd/yyyy");

            return View(productDto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductsDto productsDto)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = product.Id;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["CreatedIn"] = product.CreatedAt.ToString("MM/dd/yyyy");

                return View(productsDto);
            }


            /// Update image file if we have image uploaded new
            string newFileName = product.ImageFileName;
            if (productsDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(productsDto.ImageFile.FileName);

                string imageFullPath = _environment.WebRootPath + "/ProductsImages/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    productsDto.ImageFile.CopyTo(stream);
                }

                // Deleting old image
                string oldImagePath = _environment.WebRootPath + "/ProductsImages/" + product.ImageFileName;
                System.IO.File.Delete(oldImagePath);


            }

            // update product
            product.Name = productsDto.Name;
            product.Brand = productsDto.Brand;
            //product.CategoryId = productsDto.CategoryId;
            product.Price = productsDto.Price;
            product.Description = productsDto.Description;
            product.ImageFileName = newFileName;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products");
        }



        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            // remove image
            string imageFilePath = _environment.WebRootPath + "/ProductsImages/" + product.ImageFileName;
            System.IO.File.Delete(imageFilePath);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategoriesByCategory(int categoryId)
        {
            // Fetch SubCategories based on the selected CategoryId
            var subCategories = await _context.SubCategories
                                               .Where(sc => sc.CategoryId == categoryId)
                                               .ToListAsync();

            // Return the SubCategories as JSON
            return Json(subCategories.Select(sc => new { id = sc.Id, name = sc.Name }));
        }

        //// AJAX action to fetch SubCategories based on CategoryId
        //public JsonResult GetSubCategories(int categoryId)
        //{
        //    var subCategories = _context.SubCategories
        //                                .Where(s => s.CategoryId == categoryId)
        //                                .ToList();
        //    return Json(subCategories);
        //}
    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductCategoryDashBoard.DBContext;
using ProductCategoryDashBoard.Models;
using ProductCategoryDashBoard.ViewModels;


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

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 5;
            int totalItems = _context.Products.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);//total Pages

            page = (page <  1) ? 1 : (page > totalPages) ? totalPages : page;

            var products = await  _context.Products.Include(p => p.Category)
                                                  //.Where(p => p.Price < (int)2)
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

            // Pass the categories to the view
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

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
                                  .FirstOrDefaultAsync(p => p.Name == productsDto.Name &&
                                                            p.Brand == productsDto.Brand &&
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
            product.CategoryId = productsDto.CategoryId;
            product.Price = productsDto.Price;
            product.Description = productsDto.Description;
            product.ImageFileName = newFileName;

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }



        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            // remove image
            string imageFilePath = _environment.WebRootPath + "/ProductsImages/" + product.ImageFileName;
            System.IO.File.Delete(imageFilePath);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}
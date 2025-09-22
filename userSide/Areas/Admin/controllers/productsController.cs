using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using userSide.Areas.Admin.services;
using userSide.Data;
using userSide.Models;

namespace userSide.Areas.Admin.controllers
{
    [Area("Admin")]
    public class productsController : Controller
    {
        ApplicationContextDb context = new ApplicationContextDb();
        // GET: productsController
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var totalItems = context.products.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = context.products
                .OrderBy(p => p.productId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            product product = new product();

            ViewBag.categories = context.categories;

            return View(product);
        }
        [HttpPost]
        public IActionResult Create(product productt ,IFormFile imageFile)
        {
           productServices productServic = new productServices();
            string fileName = productServic.uploadImage(imageFile);
                // Save relative path to database if needed
                productt.imagePhoto = fileName;

            ViewBag.categories = context.categories;

            if (productt == null)
            {
                ModelState.AddModelError("productId", "The Catt is Null !!!! ");
                return View("Careate", productt);
            }
            if (!ModelState.IsValid)
            {
       

                ModelState.AddModelError("productId", "The product is not valid!");
                return View(productt);
            }

            context.products.Add(productt);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {

            product product = context.products.Find(id);
    
            var productServices = new productServices();

            if (productServices.deleteImage(product.imagePhoto))
            {
                context.products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("index");
        }

        public IActionResult Edit(int id) { 
               var prod = context.products.Find(id);
            ViewBag.categories = context.categories;

            return View(prod);
        
        }
     
        public IActionResult update(product product, IFormFile imageFile)
        {
            var existingProduct = context.products
                .AsNoTracking()
                .FirstOrDefault(p => p.productId == product.productId);

            if (existingProduct == null)
            {
                ModelState.AddModelError("", "The Product Not Exist Before !!!!!!! ");
                return RedirectToAction("Index");
            }

            if (imageFile is null)
            {
                // Keep the old image
                product.imagePhoto = existingProduct.imagePhoto;
            }
            else if (imageFile is not null)
            {
                // Replace the old image
                productServices prods = new productServices();
                prods.deleteImage(existingProduct.imagePhoto);
                string newImage = prods.uploadImage(imageFile);
                product.imagePhoto = newImage; 
            }
            context.products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            product existingProduct = context.products.Find(id);
            if (existingProduct == null) {
                ModelState.AddModelError("", "The Objext Is Not Exist!!!");
                return View("index");

            }
            ViewBag.categories = context.categories;
            return View(existingProduct);
        }


    }
}

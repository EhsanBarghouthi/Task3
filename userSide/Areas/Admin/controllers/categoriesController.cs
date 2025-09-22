using global::userSide.Data;
using global::userSide.Models;
using Microsoft.AspNetCore.Mvc;
using userSide.Data;
using userSide.Models;

namespace userSide.Areas.Admin.controllers
{
    [Area("Admin")]
    public class categoriesController : Controller
    {
        ApplicationContextDb context = new ApplicationContextDb();


        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var totalItems = context.categories.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var categories = context.categories
                .OrderBy(c => c.categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(categories);
        }
        

        public IActionResult Create()
        {
            category category = new category();
            return View(category);
        }
        public IActionResult save(category catt)
        {
            if (catt == null)
            {
                ModelState.AddModelError("categoryId", "The Catt is Null !!!! ");
                return View("Create", catt);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("categoryId", "The Catt is Not Valid !!!! ");
                return View("Create", catt);
            }
            context.categories.Add(catt);
            context.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Details(int id)
        {
            category catt = context.categories.Find(id);
            if (catt == null)
            {
                ModelState.AddModelError("CategoryId", "The category does not exist.");
                return RedirectToAction("Index");
            }
            return View(catt);
        }

        public IActionResult delete(int id)
        {
            category category = context.categories.Find(id);
            if (category == null)
            {
                ModelState.AddModelError("categoryId", "The Category Not Exist!!!!!");
                return RedirectToAction("index");
            }
            context.categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            category category = context.categories.Find(id);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId", "The Category Not Exist !!!!!");
                return RedirectToAction("index");
            }
            return View(category);

        }
        public IActionResult update(category catt)
        {
            if (catt == null)
            {
                ModelState.AddModelError("", "Category data is missing.");
                return View("Edit", catt);
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", catt);
            }

            category cattInDb = context.categories.Find(catt.categoryId);

            if (cattInDb == null)
            {
                ModelState.AddModelError("", "The category does not exist.");
                return View("Edit", catt);
            }

            // Update only editable fields
            cattInDb.categoryName = catt.categoryName;
            cattInDb.categoryType = catt.categoryType;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}


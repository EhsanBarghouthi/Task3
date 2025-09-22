using Microsoft.AspNetCore.Mvc;
using userSide.Data;
using userSide.Models;

namespace userSide.Areas.Customer.controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationContextDb context = new ApplicationContextDb();

        public IActionResult Index()
        {
            ViewBag.categories = context.categories;
            ViewBag.products=context.products;

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}

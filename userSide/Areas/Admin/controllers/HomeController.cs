using Microsoft.AspNetCore.Mvc;
using userSide.Data;
using userSide.Models;

namespace userSide.Areas.Admin.controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

    }
}

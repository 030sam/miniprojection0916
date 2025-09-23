using Microsoft.AspNetCore.Mvc;
using YourApp.Models;
using Newtonsoft.Json; // make sure you have this

namespace WebApplication2.Controllers
{
    public class Home : Controller
    {
        private readonly AppDbContext _context;
        public Home(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            ViewBag.ProductsJson = JsonConvert.SerializeObject(products);
            //var products = _context.Products.ToList();
            return View();
        }
        public IActionResult Browse()
        {
            var products = _context.Products.ToList();
            //var products = _context.Products.ToList(); // All details
            ViewBag.ProductsJson = JsonConvert.SerializeObject(products);
            return View(products);
        }
        public IActionResult Upload()
        {
            return View();
        }

    }
}

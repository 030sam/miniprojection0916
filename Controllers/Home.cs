using Microsoft.AspNetCore.Mvc;
using YourApp.Models;
using Newtonsoft.Json; // make sure you have this

namespace WebApplication2.Controllers
{
    public class Home : Controller
    {
        private  AppDbContext _context;
        private  ReacterDbContext ReacterContext;
        private  UserDbContext UserContext;

        // 修正 CS8618: 為 ReactedContetx 提供建構式初始化
        public Home(AppDbContext context, ReacterDbContext reactedContext ,UserDbContext userconext)
        {
            _context = context;
            ReacterContext = reactedContext;
            UserContext = userconext;
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
            ViewBag.UsersJson = JsonConvert.SerializeObject(UserContext.User.ToList());
            ViewBag.ReactersJson = JsonConvert.SerializeObject(ReacterContext.Reacters.ToList());
            return View(products);
        }
        public IActionResult Upload()
        {
            ViewBag.UsersJson = JsonConvert.SerializeObject(UserContext.User.ToList());
            return View();
        }

    }
}

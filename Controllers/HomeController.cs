using Microsoft.AspNetCore.Mvc;
using MyUserApp.Models;
using MyUserApp.Services;
using MyUserApp.Interface;
using System.Diagnostics;


namespace MyUserApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _booksService;
        private readonly UserListInterface _context;


        public HomeController(ILogger<HomeController> logger, UserService booksService, UserListInterface context)
        {
            _logger = logger;
            _booksService = booksService;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User newUser)
        {
            await _booksService.CreateAsync(newUser);
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_context.GetUsers());
        }

        [HttpGet]
        public IActionResult Details(string name)
        {
            var md = _context.Get(name);
            return View(md);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
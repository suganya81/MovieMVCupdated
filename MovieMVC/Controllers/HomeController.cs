using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Data;
using MovieMVC.Models;
using System.Diagnostics;

namespace MovieMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieMVCContext _context;
        private dynamic? filteredPosts;

        public HomeController(ILogger<HomeController> logger, MovieMVCContext context)
        {
            _logger = logger;
            _context = context;
        }

        private List<Post> GetAllPosts()
        {
            List<Post> posts = _context.Posts.OrderByDescending(p => p.ReleaseDate).ToList();
            return posts;
        }
        //public IActionResult Index(string search)
        //{
        //    List<Post> posts = GetAllPosts();
            
        //    return View(posts);
        //}
        public async Task<ActionResult> Index(string SearchString)
        {

            ViewData["CurrentFilter"] = SearchString;
            var posts = from t in _context.Posts
                        select t;
            if (!string.IsNullOrEmpty(SearchString))
            {
                posts = posts.Where(p => p.Title.ToLower().Contains(SearchString.ToLower()));
            }
            List<Post> postList = await posts.ToListAsync();

             return View(postList);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Areas.Identity.Data;
using MovieMVC.Data;
using MovieMVC.Models;
using System.Security.Claims;

namespace MovieMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly MovieMVCContext _context;
        private readonly UserManager<MovieMVCUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostsController(MovieMVCContext context, UserManager<MovieMVCUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Posts
        [Authorize(Roles = "Admin,Manager,Member")]  // Only users with these roles can access
        public async Task<IActionResult> Index()
        {
            var movieMVCContext = _context.Posts.Include(p => p.CategoryName).Include(p => p.User);
            return View(await movieMVCContext.ToListAsync());
        }
        public IActionResult AccessDenied()
        {
            return View("Accesdenied");
        }

        // GET: Posts/Details/5
        [Authorize(Roles = "Admin,Manager,Member")]  // Only users with these roles can access
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.CategoryName)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        [Authorize]
        /*[Authorize(Roles = "Admin,Manager")] */ // Only Admin and Manager can create posts
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return AccessDenied();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        /*[Authorize(Roles = "Admin,Manager,User")]*/  // Only Admin and Manager can create posts
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Status,CreatedAt,ReleaseDate,ImagePost,CategoryId,UserId")] Post post, IFormFile file)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", post.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                post.User = user;


                if (file != null && file.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var Uimage = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                    post.ImagePost = @"\img\" + fileName;

                    using var fileStream = new FileStream(Path.Combine(Uimage, fileName), FileMode.Create);
                    await file.CopyToAsync(fileStream);

                }
                post.CreatedAt = DateTime.Now;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            else
            {
                return AccessDenied();

            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.


        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Admin,Manager")]  // Only Admin and Manager can edit posts
        public async Task<IActionResult> Edit(int? id)

        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", post.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]  // Only Admin and Manager can edit posts
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,CreatedAt,ReleaseDate,ImagePost,CategoryId,UserId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", post.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Admin")]  // Only Admin can delete posts
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.CategoryName)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]  // Only Admin can delete posts
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'MovieMVCContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

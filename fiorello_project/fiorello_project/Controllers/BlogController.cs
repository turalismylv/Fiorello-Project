using fiorello_project.DAL;
using fiorello_project.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = new BlogIndexViewModel
            {
                Blogs = await _appDbContext.Blogs.ToListAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _appDbContext.Blogs.FindAsync(id);

            if (blog == null) return NotFound();

            var model = new BlogDetailsViewModel
            {
                Title = blog.Title,
                CreateDate = blog.CreateDate,
                Description = blog.Description,
                PhotoName = blog.PhotoName,
            };

            return View(model);
            
        }


    }
}

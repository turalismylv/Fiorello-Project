using fiorello_project.DAL;
using fiorello_project.ViewModels.FaqPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.Controllers
{
    public class FaqPageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public FaqPageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new FaqPageIndexViewModel
            {
                FaqPages = await _appDbContext.FaqPages.OrderBy(fp => fp.Order).ToListAsync()
            };
            return View(model);
        }
    }
}

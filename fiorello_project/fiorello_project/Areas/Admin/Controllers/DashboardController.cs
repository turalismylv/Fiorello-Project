using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

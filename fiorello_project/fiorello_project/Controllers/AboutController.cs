using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

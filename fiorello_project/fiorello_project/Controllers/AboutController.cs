using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

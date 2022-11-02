using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    public class FaqPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

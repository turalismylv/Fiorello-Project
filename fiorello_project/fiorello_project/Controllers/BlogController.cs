using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }


    }
}

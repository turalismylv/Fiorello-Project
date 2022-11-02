using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

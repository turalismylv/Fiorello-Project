using fiorello_project.ViewModels.Product;
using fiorello_project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            

            var model = new ProductIndexViewModel
            {
                Products = await _appDbContext.Products.OrderByDescending(p=>p.Id).ToListAsync()
            };

            
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product=await _appDbContext.Products.Include(p=>p.ProductPhotos).Include(p=>p.Category).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            var model = new ProductDetailsViewModel
            {
                Id = product.Id,
                Status = product.Status,
                Category = product.Category,
                Description = product.Description,
                Quantity = product.Quantity,
                Title = product.Title,
                Dimenesion = product.Dimenesion,
                MainPhoto = product.MainPhotoName,
                Weight = product.Weight,
                Price = product.Price,
                Photos = product.ProductPhotos,
                


            };

            return View(model);
        }
    }
}

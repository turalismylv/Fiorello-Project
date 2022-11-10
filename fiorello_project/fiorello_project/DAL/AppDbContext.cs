using fiorello_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.DAL
{
    public class AppDbContext :IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> productPhotos { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<FaqPage> FaqPages { get; set; }
        public DbSet<HomeMainSlider> HomeMainSliders { get; set; }
        public DbSet<HomeMainSliderPhoto> HomeMainSliderPhotos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}

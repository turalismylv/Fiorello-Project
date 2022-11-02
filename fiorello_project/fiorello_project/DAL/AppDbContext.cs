using fiorello_project.Models;
using Microsoft.EntityFrameworkCore;

namespace fiorello_project.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> productPhotos { get; set; }
    }
}

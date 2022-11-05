namespace fiorello_project.Areas.Admin.ViewModels.Blog
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public IFormFile MainPhoto { get; set; }
    }
}

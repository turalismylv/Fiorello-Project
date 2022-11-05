namespace fiorello_project.Areas.Admin.ViewModels.HomeMainSlider
{
    public class HomeMainSliderCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile SubPhoto { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}

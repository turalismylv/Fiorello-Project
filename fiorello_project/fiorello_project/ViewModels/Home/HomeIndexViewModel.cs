namespace fiorello_project.ViewModels.Expert
{
    public class HomeIndexViewModel
    {
        public List<Models.Expert> Experts { get; set; }
        public List<Models.Product> Products { get; set; }

        public Models.HomeMainSlider HomeMainSlider { get; set; }
    }
}

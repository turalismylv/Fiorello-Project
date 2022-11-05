﻿namespace fiorello_project.Areas.Admin.ViewModels.Expert
{
    public class ExpertUpdateViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        public string? PhotoName { get; set; }
        public IFormFile? Photo { get; set; }
    }
}

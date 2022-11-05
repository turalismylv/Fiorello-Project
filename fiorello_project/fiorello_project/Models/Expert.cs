using System.ComponentModel.DataAnnotations.Schema;

namespace fiorello_project.Models
{
    public class Expert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string  PhotoName { get; set; }
      


    }
}

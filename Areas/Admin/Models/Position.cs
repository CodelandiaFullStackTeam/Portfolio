using System.ComponentModel.DataAnnotations;

namespace Portfolio.Areas.Admin.Models
{
    public class Position
    {
        public Position()
        {
            Persons = new List<Person>();
            Experiences = new();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Deleted { get; set; }
        public List<Person> Persons { get; set; }
        public List<Experience> Experiences { get; set; }
    }

}

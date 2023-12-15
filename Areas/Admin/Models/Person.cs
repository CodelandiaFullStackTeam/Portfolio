using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Areas.Admin.Models
{
    public class Person
    {
        public Person()
        {
            Positions = new List<Position>();
            Skills = new();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        // not map
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string WebsiteAdress { get; set; }
        public string ImagePath { get; set; }
        public string CvPath { get; set; }
        public string Description { get; set; }
        public int Deleted { get; set; }
        public List<Position> Positions { get; set; }
        public List<Skill> Skills { get; set; }
    }


}

namespace Portfolio.Areas.Admin.Models
{
    public class Skill
    {
        public Skill()
        {
            Persons = new();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Deleted { get; set; }
        public List<Person> Persons { get; set; }

    }


}

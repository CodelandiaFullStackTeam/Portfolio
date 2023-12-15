namespace Portfolio.Areas.Admin.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public bool IsShownMainPage { get; set; }
        public int Deleted { get; set; }
    }


}

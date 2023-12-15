using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Areas.Admin.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public int PositionId { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        //not map
        [NotMapped]
        public bool IsCurrentWork => LeaveDate == null;
        public int Deleted { get; set; }
        public Position Position { get; set; }
    }


}

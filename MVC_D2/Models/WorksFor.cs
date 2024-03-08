using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D2.Models
{
    public class WorksFor
    {
        [ForeignKey("employee")]
        public int ESSn { get; set; }
        [ForeignKey("project")]
        public int Pno { get; set; }
        public int Hours { get; set; }
        
        //Navigation Properties
        public Employee employee { get; set; }
        public Project project { get; set; }
    }
}

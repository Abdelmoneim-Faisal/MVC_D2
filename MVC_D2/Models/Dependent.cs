using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D2.Models
{
    public class Dependent
    {
        public int ESSN { get; set; }
        public string Dependent_name { get; set; }
        public string? Sex { get; set; }
        public DateTime? Bdate { get; set; }

        //Navigation Properties
        [ForeignKey("ESSN")]
        public Employee employee { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D2.Models
{
    public class Departments
    {
        [Display(Name = "Department")]
        public string Dname { get; set; }
        [Key]
        public int Dnum { get; set; }
        [ForeignKey("manager")]
        [Display(Name = "Manager")]

        public int? MGRSSN { get; set; }
        [Display(Name = "Start Date")]
        public DateTime MGRStart_Date { get; set; }

        //Navigation Properties
        public List<Project> Projects { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee manager { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D2.Models
{
    public class Employee
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        [Key]
        public int SSN { get; set; }
        public DateTime? Bdate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }
        
        [Column(TypeName ="money")]
        public decimal? Salary { get; set; }

        [ForeignKey("supervisor")]
        public int? Superssn { get; set; }
        public int? Dno { get; set; }

        //Navigation Properties
        public List<Dependent> dependents { get; set; }= new List<Dependent>();
        public Employee EmpSupervisor { get; set; }
        public List<Employee> team {  get; set; } = new List<Employee>(); 
        public List<WorksFor> empProjects { get; set; } = new List<WorksFor>();
        public Departments department { get; set; }

    }
}

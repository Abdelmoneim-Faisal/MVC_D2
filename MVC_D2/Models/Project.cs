using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_D2.Models
{
    public class Project
    {
        public string Pname { get; set; }
        [Key]
        public int Pnumber { get; set; }
        public string Plocation { get; set; }
        public string City { get; set; }
        [ForeignKey("department")]
        public int? Dnum { get; set; }

        //Navigation Properties
        public List<WorksFor> empProjects { get; set; } = new List<WorksFor>();
        public Departments department { get; set; }

    }
}

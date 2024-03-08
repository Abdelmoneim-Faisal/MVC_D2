using Microsoft.EntityFrameworkCore;

namespace MVC_D2.Models
{
    public class EmpContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Dependent> Dependants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorksFor> WorksFor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5NJ8LIP;Database=MVC_D2;Trusted_Connection=True; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependent>().HasKey(d => new { d.ESSN, d.Dependent_name });
            modelBuilder.Entity<Employee>().HasMany(e=>e.team).WithOne(l=>l.EmpSupervisor).HasForeignKey(l=>l.Superssn);
            modelBuilder.Entity<WorksFor>().HasKey(w => new { w.ESSn, w.Pno });
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.Dno);
        }
    }
}

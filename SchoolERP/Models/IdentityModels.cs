using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SchoolERP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeID { get; set; }
        public int status { get; set; }

        public string Role { get; set; }
        [ForeignKey("EmployeeID")]

        public Employee Employee { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Fees> Fees { get; set; }
        public DbSet<ClassStandard> ClassStandards { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }
        public DbSet<Admissions> Admissions { get; set; }
        
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Employee>().HasMany(i => i.Admissions).WithRequired().WillCascadeOnDelete(true);
          //  modelBuilder.Entity<ClassStandard>().HasMany(i => i.Admissions).WithRequired().WillCascadeOnDelete(true);
          //  modelBuilder.Entity<Employee>().HasMany(i => i.classstandards).WithRequired().WillCascadeOnDelete(true);
        }

    }

  
}
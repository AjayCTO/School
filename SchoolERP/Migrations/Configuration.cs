namespace SchoolERP.Migrations
{
    using SchoolERP.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolERP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolERP.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Employee.Add(
              new Employee { Id = 1, FirstName = "Admin", LastName = "test", Email = "admin@admin.com", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, DateOfBirth = DateTime.Now, RegistrationDate = DateTime.Now, EnrolledDate = DateTime.Now, Role = "Admin", EmpCode = Guid.NewGuid().ToString(), Address = "test" });

            context.Users.Add(
              new ApplicationUser { Id = "1", UserName = "Admin", EmployeeID = 1, Role = "Admin", PasswordHash = "ABAHsqfS5vk43MxsQBDVS6jdYpcCNgGp9WbGWm2rZ/nN1NzqVtedgkqjXaueZbEcfw==", SecurityStamp = "0fef1a3b-cd26-42e7-b448-f04124fe-13ce-4d6b-8e50-f18bf1718c60" });
            //
        }
    }
}

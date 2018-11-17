using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolERP.Models
{
    public class Employee : Person
    {



        public string EmpCode { get; set; }



        public DateTime EnrolledDate { get; set; }
        public string Role { get; set; }


        public virtual ICollection<ClassStandard> classstandards { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Admissions> Admissions { get; set; }
        
    }
}
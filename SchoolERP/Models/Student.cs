using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolERP.Models
{
    public class Student : Person
    {



        public string StudentCODE { get; set; }



        public DateTime EnrolledDate { get; set; }
        public string ParentContact { get; set; }
    }
}
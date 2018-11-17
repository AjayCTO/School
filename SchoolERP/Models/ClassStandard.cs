using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolERP.Models
{
    public class ClassStandard
    {



        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Roomno { get; set; }

        public string FloorNo { get; set; }

        public string Section { get; set; }

        public int EmployeeID { get; set; }

        public decimal MaxStudents { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("EmployeeID")]

        public Employee Employee { get; set; }

        public virtual ICollection<Admissions> Admissions { get; set; }


    }
}
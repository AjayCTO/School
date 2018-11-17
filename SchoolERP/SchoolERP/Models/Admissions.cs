using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolERP.Models
{
    public class Admissions
    {


        [Key]
        public int Id { get; set; }
        public string AdmissionCode { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [Required]
        public DateTime SessionStart { get; set; }
        [Required]
        public DateTime SessionEnd { get; set; }
        //[Required]
        public int? EmployeeID { get; set; }

        [Required]
        public int StandardId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public int AdmissionStatus { get; set; }

        public int FeeStatus { get; set; }

        public decimal FeeDeposited { get; set; }

        public decimal FeeRemaining { get; set; }

        [ForeignKey("EmployeeID")]

        public Employee Employee { get; set; }


        [ForeignKey("StudentId")]

        public Student Student { get; set; }

        [ForeignKey("StandardId")]

        public ClassStandard ClassStandard { get; set; }
    }
}
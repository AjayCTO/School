using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERP.Models
{
    public class Fees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
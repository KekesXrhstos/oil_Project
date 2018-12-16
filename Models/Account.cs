using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class Account
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


        public virtual Employee Employee { get; set; }
    }
}
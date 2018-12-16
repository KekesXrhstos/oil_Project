using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class WorkContract
    {
        public DateTime DateOfHire { get; set; }


        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
       
        public virtual Employee Employee { get; set; }
    }
}
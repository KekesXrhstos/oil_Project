using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class ContactDetails
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Perfecture { get; set; }
        public string PostalCode { get; set; }


        public virtual Employee Employee { get; set; }
    }
}
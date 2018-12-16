using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class PersonalDetails
    {
        public enum FamilyStatus
        {
            UnMarried = 1,
            Married,
            Divorced,
            Widowed
        }

        public enum SexStatus
        {
            Male = 1,
            Female,
            Other
        }

        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public FamilyStatus CurrentFamilyStatus { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public SexStatus Sex { get; set; }
        public string SSN { get; set; } //to amka re aoua
        public string IdentityCard { get; set; }


        public virtual Employee Employee { get; set; }
    }
}
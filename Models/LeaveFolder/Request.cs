using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.LeaveFolder
{
    public class Request
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        public int LeaveID { get; set; }
        public virtual Leave Leave { get; set; }

        public DateTime DateRequestedLeave { get; set; }
        public bool IsAccepted { get; set; }
    }
}
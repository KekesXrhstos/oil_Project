using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.ShiftFolder
{
    public class Assignment
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.ShiftFolder
{
    public class Post
    {
        public int ID { get; set; }

        //connection 1-N between Employee and Post
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        //connection 1-N between Shift and Post
        public int ShiftID { get; set; }
        public virtual Shift Shift { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; } //N-N with Project. We have to decide if there ll be a mid talbe.
    }
}
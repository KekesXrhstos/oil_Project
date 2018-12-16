using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class Project
    {
        public enum ProgressLabel
        {
            Pending,
            InProccess,
            Canceled,
            Completed
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; } //mexri pote prepei na to exei etoimo
        public DateTime? EndedDate { get; set; }
        public ProgressLabel Progress { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; } //N-N with Post. We have to decide if there ll be a mid talbe.


    }
}
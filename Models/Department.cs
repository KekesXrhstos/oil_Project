using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class Department
    {
        public enum Type
        {
            HR=1,
            Shop,
            Production           
        }


        public int ID { get; set; }
        public Type Name { get; set; }
        public string Address { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<WeeklySchedule> WeeklySchedules { get; set; }
    }
}
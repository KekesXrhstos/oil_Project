using EmployeeProject.Models;
using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.ViewModels
{
    public class DepartmentData
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<WeeklySchedule> WeeklySchedules { get; set; }
        public IEnumerable<WorkDay> WorkDays { get; set; }
        public IEnumerable<Shift> Shifts { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }

        public DepartmentData()
        {

        }
    }
}
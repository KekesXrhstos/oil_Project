using EmployeeProject.Models;
using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.ViewModels
{
    public class ShiftData
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Shift> Shifts { get; set; }


    }
}
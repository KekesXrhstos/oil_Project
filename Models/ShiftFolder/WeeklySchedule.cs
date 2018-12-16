using EmployeeProject.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.ShiftFolder
{
    public class WeeklySchedule
    {
        public int ID { get; set; }
        public DateTime StartOfWeek { get; set; }

        public int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<WorkDay> WorkDays  { get; set; }

        private void CreateANewWeeklySchedule(EmployeeProjectDbContext db, WeeklySchedule weeklySchedule)
        {
            try
            {
                if (weeklySchedule != null)
                {
                    db.WeeklySchedules.Add(weeklySchedule);
                    db.SaveChanges();
                }
            }
            catch (DataException e)
            {
                throw new DataException(e.Message);
            }
        }

        public void AssignWorkDaysToWeeklySchedule(EmployeeProjectDbContext db,WeeklySchedule weeklySchedule,Department department)
        {

        }
    }
}
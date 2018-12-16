using EmployeeProject.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.ShiftFolder
{
    public class WorkDay
    {
        
        public int ID { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<WeeklySchedule> WeeklySchedules { get; set; }

        //connection N-N between workDay and Shifts
        public virtual ICollection<Shift> Shifts { get; set; }


        private void CreateANewWorkDay(EmployeeProjectDbContext db, WorkDay workDay)
        {
            try
            {
                if (workDay != null)
                {
                    db.WorkDays.Add(workDay);
                    db.SaveChanges();
                }
            }
            catch (DataException e)
            {
                throw new DataException(e.Message);
            }
        }

        public void AssignShiftsToWorkDay(EmployeeProjectDbContext db,WorkDay workDay,Department department)
        {
            //an den yparxei h workDay sth vash tote thn dhmiourgw
            if (!db.WorkDays.Contains(workDay))
            {
                CreateANewWorkDay(db, workDay);
            }

            foreach(var shift in workDay.Shifts)
            {
                shift.AssignEmployeesToShift(db, shift, department);
            }
        }
    }
}
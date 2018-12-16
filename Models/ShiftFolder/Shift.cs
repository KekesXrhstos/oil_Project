using EmployeeProject.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProject.Models.ShiftFolder
{
    public class Shift
    {
        public int ID { get; set; }
        public enum Shifts
        {
            Morning = 1,
            Evening = 2,
            Night = 3
        }

        public const int MinNumberOfManager = 1;
        public const int MinNumberOfWorkers = 3;
        public Shifts DayShift { get; set; }
        public decimal ShiftDurationHours { get; set; }

        //connection 1-N between Shifts and Project
        public virtual ICollection<Post> Posts { get; set; }

        //connection N-N between Shifts and Schedule
        public virtual ICollection<WorkDay> WorkDays { get; set; }

        private void CreateANewShift(EmployeeProjectDbContext db,Shift shift)
        {
            try
            {
                if (shift != null)
                {
                    db.Shifts.Add(shift);
                    db.SaveChanges();
                }    
            }
            catch (DataException e)
            {
                throw new DataException(e.Message);
            }
        }

        public void AssignEmployeesToShift(EmployeeProjectDbContext db, Shift shift, Department department)
        {
            //an den yparxei h vardia sth vash tote thn dhmiourgw
            if (!db.Shifts.Contains(shift))
            {
                CreateANewShift(db, shift);
            }

            //fernw olous tous ergazomenous poy douleyoun sto department
            var allEmployeesOfDepartment = db.Employees
                .Where(d => d.Department.ID == department.ID);
            
             
            foreach(var employee in allEmployeesOfDepartment)
            {
                //gia department me 3 vardies
                var listMorningIDs = new List<int>() { shift.ID, shift.ID - 1, shift.ID + 1, shift.ID + 2, shift.ID +3, shift.ID +4};
                var listEveningIDs = new List<int>() { shift.ID, shift.ID - 1, shift.ID + 1 };
                var listNightIDs = new List<int>() { shift.ID, shift.ID -1, shift.ID -2, shift.ID + 1};

                switch(shift.DayShift)
                {
                    case Shifts.Morning:
                        if (!employee.Posts.Select(post => post.Shift.ID)
                                         .Intersect(listMorningIDs)
                                         .Any())
                        {
                            var post = new Post()
                            {
                                Shift = shift,
                                Employee = employee
                            };

                            try
                            {
                                employee.Posts.Add(post);
                                db.SaveChanges();
                            }
                            catch (DataException e)
                            {

                                throw new DataException(e.Message);
                            }
                        }
                        break;
                    case Shifts.Evening:
                        if(!employee.Posts.Select(post => post.Shift.ID)
                                         .Intersect(listEveningIDs)
                                         .Any())
                        {
                            var post = new Post()
                            {
                                Shift = shift,
                                Employee = employee
                            };

                            try
                            {
                                employee.Posts.Add(post);
                                db.SaveChanges();
                            }
                            catch (DataException e)
                            {

                                throw new DataException(e.Message);
                            }
                        }
                        break;
                    case Shifts.Night:
                        if (!employee.Posts.Select(post => post.Shift.ID)
                                         .Intersect(listNightIDs)
                                         .Any())
                        {
                            var post = new Post()
                            {
                                Shift = shift,
                                Employee = employee
                            };

                            try
                            {
                                employee.Posts.Add(post);
                                db.SaveChanges();
                            }
                            catch (DataException e)
                            {

                                throw new DataException(e.Message);
                            }
                        }
                        break;
                    default:

                        break;
                }
            }


        }

    }
}
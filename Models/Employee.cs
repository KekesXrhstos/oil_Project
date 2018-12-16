using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeProject.Models.EvaluationFolder;
using EmployeeProject.Models.LeaveFolder;
using EmployeeProject.Models.DAL;
using System.Data.Entity;
using System.Data;

namespace EmployeeProject.Models
{
    public class Employee
    {
        public enum TypeOfInsurance
        {
            Public = 1,//search
            Private
        }

        public enum Role
        {
            Administator = 1,
            Manager,
            Worker
        }

        public enum JobStatus
        {
            Pending = 1,
            ActiveInWork,
            LeaveWithoutSalary,
            OutOfContract,
            Fired,
            Resigned
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return Name + " " + LastName;
            }
        }
        public JobStatus MyStatus { get; set; }
        public TypeOfInsurance Insurance { get; set; }
        public Role WorkRole { get; set; }
        public int RemaingDaysOfLeave { get; set; } = 22; 
        public decimal Salary { get; set; }

        //connection 1 - 0/1        
        public virtual ContactDetails ContactDetails { get; set; }

        //connection 1 - 0/1       
        public virtual WorkContract WorkContract { get; set; }

        //connection 1 - 0/1         
        public virtual Account Account { get; set; }

        //connection 1 - 0/1         
        public virtual PersonalDetails PersonalDetails { get; set; }

        //connection 1-N between Employee and Leave
        public virtual ICollection<Request> Requests { get; set; }

        //connection 1-N between Employee and Evaluation
        public virtual ICollection<Performance> Performances { get; set; }

        //connection 1-N between Employee and Project 
        public virtual ICollection<Post> Posts { get; set; }

        //connection 1-N between Department and Employee 
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        

        //ctrors

        //methods;     

        //post create
        public Employee Create(EmployeeProjectDbContext db, Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employee;
        }

        public void Delete(EmployeeProjectDbContext db, Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public Request MakeARequestForLeave(EmployeeProjectDbContext db, Employee employee, Leave leave)
        {
            var request = new Request()
            {
                Employee = employee,
                Leave = leave,
                DateRequestedLeave = DateTime.Now.Date,
                IsAccepted = true
            };
            if (employee.RemaingDaysOfLeave < leave.HowManyDays || leave.HowManyDays <= 0)
                request.IsAccepted = false;

            if (request.IsAccepted)
                employee.RemaingDaysOfLeave -= leave.HowManyDays;

            try
            {
                db.Leaves.Add(leave);
                db.Requests.Add(request);
                db.SaveChanges();
            }
            catch (DataException e)
            {
                throw new DataException(e.Message);
            }


            return request;
        }
    }
}
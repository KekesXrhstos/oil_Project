using EmployeeProject.Models.EvaluationFolder;
using EmployeeProject.Models.LeaveFolder;
using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.DAL
{
    public class EmployeeProjectDbContext : DbContext
    {
        public EmployeeProjectDbContext() : base("EmployeeProjectContext")
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WeeklySchedule> WeeklySchedules { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkContract> WorkContracts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

 
    }
}
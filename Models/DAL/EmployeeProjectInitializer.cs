using EmployeeProject.Models.EvaluationFolder;
using EmployeeProject.Models.LeaveFolder;
using EmployeeProject.Models.ShiftFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models.DAL
{
    public class EmployeeProjectInitializer : DropCreateDatabaseIfModelChanges<EmployeeProjectDbContext>
    {
        protected override void Seed(EmployeeProjectDbContext context)
        {

            var workDays = new List<WorkDay>
            {
                new WorkDay
                {
                    Day = DayOfWeek.Monday,
                    Date = DateTime.Parse("2018-10-01")
                   
                },
                new WorkDay
                {
                    Day = DayOfWeek.Tuesday,
                    Date = DateTime.Parse("2018-10-02")


                },
                new WorkDay
                {
                    Day = DayOfWeek.Wednesday,
                    Date = DateTime.Parse("2018-10-03")

                },
                new WorkDay
                {
                    Day = DayOfWeek.Thursday,
                    Date = DateTime.Parse("2018-10-04")

                },
                new WorkDay
                {
                    Day = DayOfWeek.Friday,
                    Date = DateTime.Parse("2018-10-05")

                }
            };

            workDays.ForEach(w => context.WorkDays.Add(w));
            context.SaveChanges();



            var shifts = new List<Shift>
            {
                new Shift
                {
                    DayShift = Shift.Shifts.Morning,
                    ShiftDurationHours = 8

                },
                new Shift
                {
                    DayShift = Shift.Shifts.Evening,
                    ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Night,
                    ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Morning,
                    ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Evening,
                    ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Night,
                    ShiftDurationHours = 8
                },new Shift
                {
                    DayShift = Shift.Shifts.Morning,
                    ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Evening,
                    ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Night,
                    ShiftDurationHours = 8
                },new Shift
                {
                    DayShift = Shift.Shifts.Morning,ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Evening,ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Night,ShiftDurationHours = 8
                },new Shift
                {
                    DayShift = Shift.Shifts.Morning,ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Evening,ShiftDurationHours = 8
                },
                new Shift
                {
                    DayShift = Shift.Shifts.Night,ShiftDurationHours = 8
                }
            };

            shifts.ForEach(s => context.Shifts.Add(s));
            context.SaveChanges();

            



            var departments = new List<Department>
            {
                new Department
                {
                    Name = Department.Type.HR,
                    Address = "Panepistimiou"
                },
                new Department
                {
                    Name = Department.Type.Shop,
                    Address = "Akadimias"
                },
                new Department
                {
                    Name = Department.Type.Production,
                    Address = "Paiania"
                },

            };

            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();

            var weeklySchedules = new List<WeeklySchedule>
            {
                new WeeklySchedule
                {
                    DepartmentID = 1,
                    StartOfWeek = DateTime.Parse("2018-10-01")
                },
                new WeeklySchedule
                {
                    DepartmentID = 2,
                    StartOfWeek = DateTime.Parse("2018-10-01")                   
                },
                new WeeklySchedule
                {
                    DepartmentID = 1,
                    StartOfWeek = DateTime.Parse("2018-10-08")
                },
                new WeeklySchedule
                {
                    DepartmentID = 1,
                    StartOfWeek = DateTime.Parse("2018-10-15")
                }

            };

            weeklySchedules.ForEach(w => context.WeeklySchedules.Add(w));
            context.SaveChanges();




            var employees = new List<Employee>
            {
                new Employee
                {
                    Name = "Apo",
                    LastName = "Alexiadis",
                    Salary = 20000,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Administator,
                    DepartmentID = 1,
                    RemaingDaysOfLeave = 22

                },
                new Employee
                {
                    Name = "Kostas",
                    LastName = "Timpas",
                    Salary = 500,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker,
                    DepartmentID = 2, RemaingDaysOfLeave = 22
                },
                new Employee
                {
                    Name = "Niki",
                    LastName = "Dava",
                    Salary = 2000,
                    Insurance = Employee.TypeOfInsurance.Private,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Manager
                },
                new Employee
                {
                    Name = "Chris",
                    LastName = "Kekes",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "John",
                    LastName = "Karas",
                    Salary = 1500,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Manager
                },
                new Employee
                {
                    Name = "Panos",
                    LastName = "Makris",
                    Salary = 1500,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Manager
                },
                new Employee
                {
                    Name = "Vaggos",
                    LastName = "Boltsis-Olizadebe",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Lef",
                    LastName = "Lef",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "George",
                    LastName = "Pasparakis",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "George",
                    LastName = "Zourn",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Vaggos",
                    LastName = "Tsen",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Katerinaki",
                    LastName = "KorhProedrou",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Theodor",
                    LastName = "Antwn",
                    Salary = 8000,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Alex",
                    LastName = "Sar",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Panos",
                    LastName = "PanosPanos",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Mr",
                    LastName = "Charis",
                    Salary = 850,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "John",
                    LastName = "IC XR NK",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Lefteris",
                    LastName = "LefLefLef",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Charis",
                    LastName = "SeLew",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Sasa",
                    LastName = "Holland",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.LeaveWithoutSalary,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Peri",
                    LastName = "Aidino",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                },
                new Employee
                {
                    Name = "Homedanis",
                    LastName = "Mosh",
                    Salary = 800,
                    Insurance = Employee.TypeOfInsurance.Public,
                    MyStatus = Employee.JobStatus.ActiveInWork,
                    WorkRole = Employee.Role.Worker
                }
            };

            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();            

            var accounts = new List<Account>
            {
                new Account
                {
                    Email = "daddsa",
                    Password = "123123",
                    EmployeeID = 1
                },
                new Account
                {
                    Email = "rfrgrsf",
                    Password = "1235f",
                    EmployeeID = 2
                },
                new Account
                {
                    Email = "dsaccgtfv",
                    Password = "dsadad",
                    EmployeeID = 3
                }
            };

            accounts.ForEach(a => context.Accounts.Add(a));
            context.SaveChanges();

            var contactdetails = new List<ContactDetails>
            {
                new ContactDetails
                {
                    Address = "Agiou Vartholomeou 7",
                    City = "Paiania",
                    MobilePhone = "8765434567",
                    Perfecture = "Attikis",
                    PostalCode = "19002",
                    EmployeeID =1
                },
                new ContactDetails
                {
                    Address = "Agiou Vartholomeou 9",
                    City = "Peraias",
                    MobilePhone = "9876567",
                    Perfecture = "Attikis",
                    PostalCode = "19002",
                    EmployeeID = 2
                }
            };

            contactdetails.ForEach(c => context.ContactDetails.Add(c));
            context.SaveChanges();

            var personalsDetails = new List<PersonalDetails>
            {
                new PersonalDetails
                {
                    Sex = PersonalDetails.SexStatus.Male,
                    SSN = "45654744",
                    CurrentFamilyStatus = PersonalDetails.FamilyStatus.Divorced,
                    DateOfBirth = DateTime.Parse("1987-06-01"),
                    IdentityCard = "werrtwt",
                    NumberOfChildren = 3,
                    EmployeeID = 1
                },
                new PersonalDetails
                {
                    Sex = PersonalDetails.SexStatus.Male,
                    SSN = "45654744",
                    CurrentFamilyStatus = PersonalDetails.FamilyStatus.Divorced,
                    DateOfBirth = DateTime.Parse("1987-06-01"),
                    IdentityCard = "werrtwt",
                    NumberOfChildren = 3,
                    EmployeeID = 2
                },
            };

            personalsDetails.ForEach(p => context.PersonalDetails.Add(p));
            context.SaveChanges();
          

            var workContracts = new List<WorkContract>
            {
                new WorkContract
                {
                    DateOfHire = DateTime.Parse("2018-10-01"),
                    EmployeeID = 1
                },
                new WorkContract
                {
                    DateOfHire = DateTime.Parse("2018-10-01"),
                    EmployeeID = 2

                }
            };

            workContracts.ForEach(w => context.WorkContracts.Add(w));
            context.SaveChanges();

            //evaluation part
            var evaluations = new List<Evaluation>
            {
                new Evaluation
                {
                    StartEvaluationDate = DateTime.Parse("2018-09-01"),
                    EndEvaluationDate = DateTime.Parse("2018-09-30")
                },
                new Evaluation
                {
                    StartEvaluationDate = DateTime.Parse("2018-08-01"),
                    EndEvaluationDate = DateTime.Parse("2018-08-31")
                }
            };

            evaluations.ForEach(e => context.Evaluations.Add(e));
            context.SaveChanges();

            var performances = new List<Performance>
            {
                new Performance
                {
                    EmployeeID = 1,
                    EvaluationID = 1,
                    DateEvaluated = DateTime.Parse("2018-09-05"),
                    OveralRating = 85
                },
                new Performance
                {
                    EmployeeID = 1,
                    EvaluationID = 2,
                    DateEvaluated = DateTime.Parse("2018-08-05"),
                    OveralRating = 82
                }
            };

            performances.ForEach(p => context.Performances.Add(p));
            context.SaveChanges();



            
            var posts = new List<Post>
            {
                new Post
                {
                    EmployeeID = 1,
                    ShiftID = 1,

                },
                new Post
                {
                    EmployeeID = 1,
                    ShiftID = 4,
                },
                new Post
                {
                    EmployeeID = 1,
                    ShiftID = 7

                },
                new Post
                {
                    EmployeeID = 2,
                    ShiftID = 1

                },
                new Post
                {
                    EmployeeID = 2,
                    ShiftID = 6

                },
                new Post
                {
                    EmployeeID = 2,
                    ShiftID = 8,

                },

            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project
                {
                    Description = "Bottle",
                    Progress = Project.ProgressLabel.InProccess,
                    DueDate = DateTime.Parse("2018-10-20")
                },
                new Project
                {
                    Description = "Load on track",
                    Progress = Project.ProgressLabel.InProccess,
                    DueDate = DateTime.Parse("2018-10-20"),
                    EndedDate = DateTime.Parse("2018-10-19")
                },
                new Project
                {
                    Description = "Load on track",
                    Progress = Project.ProgressLabel.InProccess,
                    DueDate = DateTime.Parse("2018-10-20")
                },
                new Project
                {
                    Description = "Bottle",
                    Progress = Project.ProgressLabel.InProccess,
                    DueDate = DateTime.Parse("2018-10-20"),
                    EndedDate = DateTime.Parse("2018-10-19")
                },
            };

            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();

            var assignments = new List<Assignment>
            {
                new Assignment
                {
                    PostID = 1,
                    ProjectID = 1,
                    Date = DateTime.Parse("2018-10-15")
                },
                new Assignment
                {
                    PostID = 1,
                    ProjectID = 2,
                    Date = DateTime.Parse("2018-10-15")
                },
                new Assignment
                {
                    PostID = 2,
                    ProjectID = 3,
                    Date = DateTime.Parse("2018-10-15")
                },
                new Assignment
                {
                    PostID = 3,
                    ProjectID = 4,
                    Date = DateTime.Parse("2018-10-15")
                }
            };

            assignments.ForEach(a => context.Assignments.Add(a));
            context.SaveChanges();

            var leaves = new List<Leave>
            {
                new Leave
                {
                    Type = Leave.TypeOfLeave.Illness,
                    StartDateOfLeave = DateTime.Parse("2017-01-04"),
                    EndDateOfLeave = DateTime.Parse("2017-01-05")
                },
                 new Leave
                {
                    Type = Leave.TypeOfLeave.Illness,
                    StartDateOfLeave = DateTime.Parse("2017-03-10"),
                    EndDateOfLeave = DateTime.Parse("2017-03-12")
                },
                new Leave
                {
                    Type = Leave.TypeOfLeave.Illness,
                    StartDateOfLeave = DateTime.Parse("2017-01-01"),
                    EndDateOfLeave = DateTime.Parse("2017-01-02")
                },
                new Leave
                {
                    Type = Leave.TypeOfLeave.Illness,
                    StartDateOfLeave = DateTime.Parse("2017-03-03"),
                    EndDateOfLeave = DateTime.Parse("2017-03-03")
                },
                new Leave
                {
                    Type = Leave.TypeOfLeave.Pregnancy,
                    StartDateOfLeave = DateTime.Parse("2017-01-01"),
                    EndDateOfLeave = DateTime.Parse("2017-06-01")
                },
                new Leave
                {
                    Type = Leave.TypeOfLeave.Vacations,
                    StartDateOfLeave = DateTime.Parse("2017-12-20"),
                    EndDateOfLeave = DateTime.Parse("2017-12-29")
                },

            };

            leaves.ForEach(l => context.Leaves.Add(l));
            context.SaveChanges();

            var requests = new List<Request>
            {
                new Request
                {
                    EmployeeID = 1,
                    LeaveID = 6,
                    DateRequestedLeave = DateTime.Parse("2017-11-01"),
                },
                new Request
                {
                    EmployeeID = 1,
                    LeaveID = 1,
                    DateRequestedLeave = DateTime.Parse("2017-01-04"),
                },
                new Request
                {
                    EmployeeID = 2,
                    LeaveID = 2,
                    DateRequestedLeave = DateTime.Parse("2017-03-10"),
                },
                new Request
                {
                    EmployeeID = 2,
                    LeaveID = 2,
                    DateRequestedLeave = DateTime.Parse("2017-03-10"),
                },
                new Request
                {
                    EmployeeID = 2,
                    LeaveID = 5,
                    DateRequestedLeave = DateTime.Parse("2016-12-01")
                },
            };

            requests.ForEach(r => context.Requests.Add(r));
            context.SaveChanges();

            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeProject.Models;
using EmployeeProject.Models.EvaluationFolder;

namespace EmployeeProject.ViewModel
{
    public class EvaluationsData
    {
        public IEnumerable<Evaluation> Evaluations { get; set; }
        public IEnumerable<Performance> Performances { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        
    }
}
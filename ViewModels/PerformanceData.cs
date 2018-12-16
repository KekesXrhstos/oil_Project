using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmployeeProject.Models;
using EmployeeProject.Models.EvaluationFolder;
using EmployeeProject.Models.DAL;

namespace EmployeeProject.ViewModel
{
    public class PerformanceData
    {
        private EmployeeProjectDbContext db = new EmployeeProjectDbContext();

        public Employee Employee { get; set; }
        public Evaluation Evaluation { get; set; }
        public Form Form { get; set; }
        public Answer Answer { get; set; }
        public IEnumerable<Form> Forms { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public DateTime DateTime { get; set; }
        public decimal OveralRating { get; set; }
        public int FormId { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
        public bool ExistingPerformance = false;

        public DateTime EvaluationdDatetime { get; set; }


        public List<Question> GetFormQuestions(int formId)
        {
            var questionsForm = db.Forms.Single(m => m.ID == formId).Questions.ToList();
            return questionsForm;
        }

        public void SetAnswerProperties(int questionId, Answer answer)
        {
            answer.QuestionID = questionId;
        }

    }

    
}